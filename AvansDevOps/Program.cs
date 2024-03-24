// See https://aka.ms/new-console-template for more information

using AvansDevOps;

//Creating a new project
var project = new Project("AvansDevOps", new User("Piet", "piet@mail.com",[ new EmailNotificationService()]));

//Creating users and assigning them to how they want to be notified
var user1 = new User("John Doe", "john.doe@mail.com", [new EmailNotificationService(), new SlackNotificationService()]);
var user2 = new User("Jane Doe", "jane.doe@mail.com", [new SlackNotificationService()]);
var user3 = new User("Wim Ortel", "w.ortel@mail.com", [new EmailNotificationService()]);
var user4 = new User("Kees Aas", "k.aas@mail.com", [new SlackNotificationService(), new EmailNotificationService()]);

//Adding roles
var developer = new UserRole("Developer");
var tester = new UserRole("Tester");


//Adding sprint
var sprint = new ReviewSprint("Sprint 1", new DateTime(2024, 3, 20), new DateTime(2024, 03, 21), user1);

//Adding members to the project
sprint.AddMember(user2, tester);
sprint.AddMember(user3, developer);
sprint.AddMember(user4, developer);

//Adding backlog items and subtasks
var backlogItem1 = new BacklogItem("Create a new project");
var backlogItem2 = new BacklogItem("Create a new user");
var backlogItem3 = new BacklogItem("Create a new role");
var subtask1 = new Subtask("Create a new project in the database");
var subtask2 = new Subtask("Create a new project in the API");

//Adding subtasks to backlog items
backlogItem1.AddSubtask(subtask1);
backlogItem1.AddSubtask(subtask2);

//Adding backlog items to the sprint
sprint.AddBacklogItem(backlogItem1);
sprint.AddBacklogItem(backlogItem2);
sprint.AddBacklogItem(backlogItem3);

//Assigning backlog items and subtasks to users
backlogItem1.AssignTo(user3);
backlogItem2.AssignTo(user3);
backlogItem3.AssignTo(user4);
subtask1.AssignTo(user4);
subtask2.AssignTo(user4);

//Adding sprint to the project
project.AddSprint(sprint);

//Starting the sprint
sprint.StartSprint();

backlogItem1.TransitionToNextState(); // Todo -> Doing
backlogItem1.Complete(); // Complete backlog item, gives error because subtasks are not completed
subtask1.Complete(); // Complete subtask1
subtask2.Complete(); // Complete subtask2
backlogItem1.Complete(); // Complete backlog item

backlogItem1.Test("Tester", false); // Backlog item returns to todo because it was not implemented correctly
backlogItem2.TransitionToNextState(); // Todo -> Doing
backlogItem2.Complete();
backlogItem2.Test("Tester", true); // Backlog item is tested and is now ready for checking
backlogItem2.Check("Scrum Master", false); // Backlog item does not match with the DoD and returns to ready for testing

backlogItem3.TransitionToNextState(); // Todo -> Doing
backlogItem3.Complete();
backlogItem3.Test("Tester", true);
backlogItem3.Check("Scrum Master", true); // Backlog item is checked and is now done


sprint.FinishSprint();
// sprint.StartReview();
// sprint.CloseSprint(user1, "Sprint was successful!");

sprint.StartRelease(false);
sprint.CreateReport(new SprintReportPDF());

project.Commit(backlogItem1);
project.Push();

var exporter = new SprintReportTXT();
sprint.CreateReport(exporter);
