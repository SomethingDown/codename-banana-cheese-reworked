using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass, Icon("res://addons/godot-easy-icons/generated/node_icons/pixelarticons__square_alert_sharp_pixel_node.svg")]
public partial class ThreatAwarenessComponent : Node
{
    [Signal] public delegate void ThreatConfirmedEventHandler(Node entity);
    [Signal] public delegate void ThreatForgottenEventHandler(Node entity);

    [Export] public float fill_rate = 1.0f;
    [Export] public float drain_rate = 0.5f;
    [Export] public float threshold = 10.0f;
    [Export] public float confirmed_meter_bonus = 10.0f;
    private ThreatEvaluatorComponent threat_evaluator_;
    private Dictionary<Node, float> entity_threat_meter_ = new Dictionary<Node, float>();
    private HashSet<Node> confirmed_threats_ = new HashSet<Node>();
    private HashSet<Node> actively_detected_ = new HashSet<Node>();

    public override void _Ready()
    {
        threat_evaluator_ = this.GetComponent<ThreatEvaluatorComponent>();
        if (threat_evaluator_ == null) return;

        threat_evaluator_.ThreatDetected += OnThreatDetected;
        threat_evaluator_.ThreatCleared += OnThreatCleared;
    }

    private void OnThreatDetected(Node entity)
    {
        actively_detected_.Add(entity);

        if (!entity_threat_meter_.ContainsKey(entity))
            entity_threat_meter_[entity] = 0.0f;
    }

    private void OnThreatCleared(Node entity)
    {
        actively_detected_.Remove(entity);
    }
    public override void _Process(double delta)
    {
        var entities_to_remove = new List<Node>();

        entity_threat_meter_.ToList().ForEach(kv =>
        {
            Node entity = kv.Key;

            if (!GodotObject.IsInstanceValid(entity))
            {
                entities_to_remove.Add(entity);
                return;
            }

            float meter = kv.Value;

            meter += (actively_detected_.Contains(entity) ? fill_rate : -drain_rate) * (float) delta;
            meter = Mathf.Max(meter, 0f);
            entity_threat_meter_[entity] = meter;

            UpdateConfirmedState(entity, meter);

            if (meter <= 0f)
                entities_to_remove.Add(entity);
        });

        entities_to_remove.ForEach(e =>
        {
            entity_threat_meter_.Remove(e);
            confirmed_threats_.Remove(e);
            actively_detected_.Remove(e);
        });
    }
    public HashSet<Node> GetConfirmedThreats()
    {
        confirmed_threats_.RemoveWhere(e => !GodotObject.IsInstanceValid(e));
        return confirmed_threats_;
    }

    private void UpdateConfirmedState(Node entity, float meter)
    {
        bool is_above_threshold = meter >= threshold;
        bool was_confirmed = confirmed_threats_.Contains(entity);

        if (is_above_threshold && !was_confirmed)
        {
            confirmed_threats_.Add(entity);
            entity_threat_meter_[entity] += confirmed_meter_bonus;
            EmitSignal(SignalName.ThreatConfirmed, entity);
        }
        else if (!is_above_threshold && was_confirmed)
        {
            confirmed_threats_.Remove(entity);
            EmitSignal(SignalName.ThreatForgotten, entity);
        }
    }
}