# .NetStudyTask5

Study project for VSU. Exploring reflection in C#.

After loading project the form pops up, where you can insert the namespace (w/ path to it) of project, then hit button "find classes" and in the following combobox will be loaded classes of this namespace (*Note: you will need to remove hardcode sorting if you want to load your own classes, not this Task5 classes*).

Then will be created an object of chosen class, and all it's methods will be loaded into second combobox. If you choose some method, you can pick it's parameters and fill them by entering value in textbox and then hitting button **Enter**.

Beware of type conflicts, this app only accepts string values nicely (because the purpose was to learn the mechanism of reflection I decided not to push to the perfection).

After you successfully filled all parameters (personally recommend to try not setters, but void methods with funny names), you can choose any other void method and hit button "execute".
The void method will be executed and the result will be shown in MessageBox.
