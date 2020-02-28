namespace Wims
{
	public static class Help
	{
		public const string helpCommands =
@"
		List of commands:
		-----------------
Create	
	createteam...................(<teamName>)
	createboard..................(<boardName>)
	createmember.................(<memberName>)
	createbug....................(<bugTitle> <bugDescription> <Priority> <Severity>)
	createstory..................(<storyTitle> <storyDescription> <Priority> <Size>)
	createfeedback...............(<feedbackTitle> <feedbackDescription> <Rating>)

Modify
	modifybug....................(<bugTitle> <Priority/Severity/Status> <newValue>)
	modifystory..................(<storyTitle> <Priority/Size/Status> <newValue>)
	modifyfeedback...............(<feedbackTitle> <Rating/Status> <newValue>)
	addstepstobug................(<workItemTitle> <StepsToReproduce(each step is separated by '>' )>)
	addcomment...................(<workItemTitle> <memberName> <Comment>)

Listing
	filterallbugsbyassignee......(<assigneeName>)
	filterallbugsbystatus........(<bugStatus>)
	filterallstoriesbystatus.....(<storyStatus>)
	filterallstoriesbyassignee...(<assigneeName>)
	filterallfeedbacksbystatus...(<feedbackStatus>)
	sortallitemsbytitle..........()
	sortitemsbyrating............()
	sortitemsbypriority..........()
	sortitemsbyseverity..........()
	sortitemsbysize..............()
	listteams....................()
	listallmembers...............()
	listallteammembers...........()
	listallboards................()
	listallteamboards............()
	listallteamitems.............()
	listallitems.................()
	listfilterallitems...........(<Bug/Story/Feedback>)

History	
	viewworkitemhistory..........(<workItemTitle>)
	viewboardhistory.............(<boardName>)
	viewmemberhistory............(<memberName>)
	viewteamhistory..............()

Assign/unassign	
	assign.......................(<assigneName> <workItemTitle>)
	unassign.....................(<workItemTitle>)

Select	
	selectteam...................(<teamName>)
	selectboard..................(<boardName>)

Exit
	end..........................()

Help
	help.........................()

";


		public const string initialMessage =

@"=========================================
	WELCOME TO WORK MANAGEMENT SYSTEM
=========================================
";
	}
}
