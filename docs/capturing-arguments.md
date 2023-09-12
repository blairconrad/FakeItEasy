# Capturing arguments

There are a large number of [argument constraints](argument-constraints.md)
that FakeItEasy provides to restrict which calls are being configured or to
verify that particular calls were made, and custom ones can be added, but
sometimes they aren't sufficient and it becomes desirable to capture
arguments supplied in calls to fakes. Here's how to do that.

## Sample domain

Take this contrived example: