
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PanGestureRecognizer : Clickable
{
    public bool onGesture { get => base.active; }

    public TouchPhase touchPhase { get; private set; }

    public Vector2 startMousePosition { get; private set; }

    public Vector2 currentMousePosition => base.lastMousePosition;

    public Vector2 delta => this.currentMousePosition - this.startMousePosition;

    public event Action<PanGestureRecognizer> onPanGesture;

    private bool isGestureStart = false;

    public PanGestureRecognizer(Action<PanGestureRecognizer> onPanGesture)
        : base(() => { })
    {
        this.onPanGesture += onPanGesture;
    }

    protected override void ProcessDownEvent(EventBase evt, Vector2 localPosition, int pointerId)
    {
        base.ProcessDownEvent(evt, localPosition, pointerId);
        this.isGestureStart = true;
        this.startMousePosition = base.lastMousePosition;
        this.touchPhase = TouchPhase.Began;
        this.onPanGesture?.Invoke(this);
    }


    protected override void ProcessUpEvent(EventBase evt, Vector2 localPosition, int pointerId)
    {
        base.ProcessUpEvent(evt, localPosition, pointerId);

        if (!this.isGestureStart)
        {
            return;
        }
        this.touchPhase = TouchPhase.Ended;
        this.onPanGesture?.Invoke(this);
        this.isGestureStart = false;
    }

    protected override void ProcessMoveEvent(EventBase evt, Vector2 localPosition)
    {
        base.ProcessMoveEvent(evt, localPosition);
        if (!this.isGestureStart)
        {
            return;
        }
        this.touchPhase = TouchPhase.Moved;
        this.onPanGesture?.Invoke(this);
    }
}
