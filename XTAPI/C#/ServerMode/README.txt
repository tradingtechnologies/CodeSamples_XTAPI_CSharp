README.txt
ServerMode (C#)
===============================================================================


Overview
-------------------------------------------------------------------------------

This example demonstrates using the XTAPI in Server Mode to monitor order
actions.  Settings EnableServerMode also requires the application to 
authenticate using SetUniversalLogin.

Note:	Server Mode allows XTAPI applications to run independent of X_TRADER.
		Since X_TRADER is not required, a Server Mode XTAPI application will
		consume it's own X_TRADER Pro license, and orders cannot be placed or
		modified.
 

Instructions
-------------------------------------------------------------------------------

1. Enter the Universal Login information & click "Connect".
2. Working order updates will be displayed in the text box.


XTAPI Objects
-------------------------------------------------------------------------------

TTGate
TTOrderSet
TTOrderObj


Revisions
-------------------------------------------------------------------------------

Version:		1.1.0
Date Created:	06/29/2005
Notes:			None

Version:		1.2.0
Date Created:	01/09/2009
Notes:			Added conformance/production warning on the form.  Added more
				descriptive comments and general source cleanup.

Version:		1.2.1
Date Created:	01/16/2013
Notes:			Updated for GitHub.  Changed sample from using the 
				TTOrderTracker and replaced with the order status events.
				Also changed to support Universal Login.