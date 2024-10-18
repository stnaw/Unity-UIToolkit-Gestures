# Unity-UIToolkit-Gestures

Implement some basic gesture recognizers for UIToolkit, currently only supporting pan gestures, with plans to add more gestures in the future. :)

## Getting started

- PanGesture

```csharp
        this.AddManipulator(new PanGestureRecognizer((recognizer) =>
        {
            switch (recognizer.touchPhase)
            {
                case TouchPhase.Began:
                    //began
                    break;
                case TouchPhase.Moved:
                    //moved
                    break;
                case TouchPhase.Ended:
                    //ended
                    break;
            }
        }));
```

