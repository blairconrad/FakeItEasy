# Capturing arguments

There are a large number of [argument constraints](argument-constraints.md)
that FakeItEasy provides to restrict which calls are being configured or to
verify that particular calls were made, and custom ones can be added, but
sometimes they aren't sufficient and it is desirable to capture
arguments supplied in calls to fake objects. Here's how to do that.

## Simple capture

Take this contrived example:

```csharp title='"production code"'
--8<--
recipes/FakeItEasy.Recipes.CSharp/CapturingArguments.cs:IListLogger

recipes/FakeItEasy.Recipes.CSharp/CapturingArguments.cs:Popper
--8<--
```

While there are other ways to ensure that a particular list is passed
to a method, we'll pretend there aren't and capture the second argument
to `log` in a `CapturedArgument`, then verify it.

```csharp title="simple capture" linenums="1"  hl_lines="2 7 17 22"
--8<--
recipes/FakeItEasy.Recipes.CSharp/CapturingArguments.cs:SimpleCapture
--8<--
```

This is a fairly standard test with fakes, except we:

* create a `CapturedArgument` variable to store a captured argument value
* use `An<>.That.IsCapturedTo` to create a "capturing constraint" that matches any value
* use `Values` to access all the captured values so they can be asserted
* (alternative flow) use `GetLastValue` to access the most recent captured value so it can be asserted

???+ note "Values are only captured if the call matches the configuration"
    When a call configuration includes one or more argument-capturing constraints, the argument
    values are only captured if the call is triggered. If an incoming call does not match that
    configured for the method or property, no arguments are captured.

## Limitations

Capturing arguments is fairly limited right now. In particular, it suffers from these deficiencies:

* there is no way to both capture an argument and constrain by its value
* argument capture is shallow; there's no copying of object state.
  If a reference-based argument (e.g. a class instance, not a struct) is captured and
  subsequently modified by the test or production code, the updated state will be seen
  during the "assert" phase of the test.
