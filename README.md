# Hardware Scheduler

This project is a proof-of-concent multithreaded hardware scheduler. The user can define Resources, Sensors, and Tasks to schedule runs through the RunManager.
Features include:
* Dynamic scheduling, a requirement for when the tasks will take a variable amount of time on each Resource
* Single threaded scheduler which kicks off a new thread for each hardware task, guaranteeing correct Resource State
* The ability to define different sets of work for each Sample that needs to be run
* Prioritization for tasks, where the highest priority task is always run first when a required Resource becomes available
* Support for cancellation of tasks on all threads. This gives an easy way to kill a task and shut down hardware in case of emergency or loss of power.
* Full logging support

![umldiagram](https://github.com/danielwatsongt/hardware-scheduler/assets/91094606/817389df-16d6-4533-95ac-b61fc71e438f)

# Test Implementation
The SchedulerTestImplementation is an example implementation of the Scheduler project. We have defined:
* Two Camera resources
* One Liquid Dispenser resource
* One Heat Sensor, where the Liquid Dispenser requires a certain temperature threshold in order to dispense
* 10 samples, which must run through the following sequence: Camera 1, Liquid Dispense, Camera 2, Liquid Dispense, Camera 1

# Improvements
This project is a proof-of-concept. Improvements that should be made:
* Resource threads should have call-back method to manager. This allows manager to wait for available resources and start something new immediately, rather than sitting in a while() loop constantly checking states
* RunScheduler should take in Resources/Samples/Sensors from configuration files. This allows for save states and dependency injection.
* Sensors should be on a Data Stream, instead of querying them for current state whenever a certain condition is needed
