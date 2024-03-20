// See https://aka.ms/new-console-template for more information

using AvansDevOps;

var project = new Project("Test project");
project.AddMember(new User("John Doe", "j.doe@mail.com"), new UserRole("Tester"));

// var sprint = new ReleaseSprint("sprint 1");

// sprint.AddBacklogItem(new BacklogItem("Create a new project"));
//
// project.AddSprint(sprint);
//
// sprint.StartSprint();
//
// sprint.BacklogItems[0].TransitionToNextState();
// sprint.BacklogItems[0].TransitionToNextState();
// sprint.BacklogItems[0].Complete();
// sprint.BacklogItems[0].TransitionToNextState();




