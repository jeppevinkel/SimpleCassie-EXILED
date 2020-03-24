
# SimpleCassie
## Summary
SimpleCassie allows you to play CASSIE messages during certain events.
The plugin currently doesn't support many events, as it was just created to satisfy a quick need, but I am working on a system to automate adding all events with templates.

## Settings

| Setting Key      | Value Type | Default Value                                                                                                                                                                                                                                                                                         | Description                                     |
|------------------|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------|
|simpleCassie_enable|boolean|true|Enables or disables the plugin.|
|simpleCassie_\<event\>|boolean|false|Enables or disables the plugin.|
|simpleCassie_\<event\>_message|string|\<template message\>|The message for CASSIE to say.|
|simpleCassie_\<event\>_delay|float|0|Time for CASSIE to way after the event fired.|
|simpleCassie_\<event\>_noise|boolean|false|Whether the default noise should play before CASSIE talks|
### Events
```yml
roundStart
roundEnd
warheadStart
warheadCancelled
warheadDetonation
```
