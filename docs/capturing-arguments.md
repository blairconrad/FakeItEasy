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

## Capturing and constraining at the same time

Even though you can interrogate captured values after the fact, you may want to configure
fake behavior to take effect only when incoming arguments meet a constraint. You can do this
using syntax similar to that of non-capturing constraints.

```csharp title="constrained capture" linenums="1" hl_lines="7 8"
--8<--
recipes/FakeItEasy.Recipes.CSharp/CapturingArguments.cs:ConstrainedCapture
--8<--
```

## Capturing mutable arguments

### The challenge

Argument capture is shallow; there's no copying of object state.
If a reference-based argument (e.g. a class instance, not a struct) is captured and
subsequently modified by the test or production code, the updated state will be seen
during the "assert" phase of the test.

```csharp title="mutating captured values" linenums="1" hl_lines="13 14 15 21 22"
--8<--
recipes/FakeItEasy.Recipes.CSharp/CapturingArguments.cs:NaivelyCaptureMutatedList
--8<--
```

Here a single list instance is twice passed to the production code, which removes
the first element each time. The `CapturedArgument` captures a reference to the list each
time, but does not preserve the internals of the list. So by the time the `Values` are examined,
the list has had its first two elements removed, and this is reflected in the failing assertion.

It's the same effect as if the following were run:

```c#
var list = new List<int> { 1, 2, 3 };
var a = list;
list.RemoveAt(0);
var b = list;

// both a and b point to a list with elements {2, 3}
```

### Capturing frozen state

`CapturedArgument`s can be created with a transforming function (or "freezer") that runs on the
argument value before saving it away. This behavior can be used to insulate the captured values
from subsequent mutations.

```csharp title="freezing state of captured values" linenums="1" hl_lines="2 3"
--8<--
recipes/FakeItEasy.Recipes.CSharp/CapturingArguments.cs:CaptureCopiedMutatedList
--8<--
```

You can even transform values into a different type:

```csharp title="freezing state of captured values as new type" linenums="1" hl_lines="2 3 19 20"
--8<--
recipes/FakeItEasy.Recipes.CSharp/CapturingArguments.cs:CaptureCopiedMutatedListToNewType
--8<--
```

Aside from changing the freezer function, the `CapturedArgument` needs to have the typeparams
supplied for the argument value and the captured value.
