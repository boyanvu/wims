https://trello.com/b/aroYwPEK/wims-boian-rado - Trello board - Radoslav and Boian

```
                    Work Item Management System


Application supports:
-multiple teams - every team can have boards and members
-multiple boards - every board can have multiple work items
-multiple members - every member has to be added to a team, can be assigned to a specific work item
-multiple work items - bug, story, feedback

Every 
    Team - name, boards, members, history
    Board - name, work items, history
    Member - name, work items, history
    All work items have title, description, comments and history:
        Bug: priority, severity, status and assignee
        Story: priority, size, status and asignee
        Feedback: rating, status
        
Commands: 
    Create - team, member, board, work item, comment
    Add - comment to a work item, member to a team
    Modify - work item(bug, story, feedback)
    List - all items, filtered, sorted
    Select - team and board(change the current team or board)
    Show history - work item, board, member, team
    Assign - assign/unassign work item to a specific member of the current team
```