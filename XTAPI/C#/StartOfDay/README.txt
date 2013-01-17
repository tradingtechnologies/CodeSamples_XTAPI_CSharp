README.txt
StartOfDay (C#)
===============================================================================

Overview
-------------------------------------------------------------------------------

This example demonstrates using the XTAPI to monitor and set StartOfDay (SOD)
records.  This sample requires you have administrative risk privileges.

Instructions
-------------------------------------------------------------------------------

1. Login with administrator credentials
2. Click Get Records to get SOD records for a Member Group Trader
3. Drag and Instrument onto the form
4. Perform add, delete, or delete all SOD records
5. Click "Save" to save the record to the SODSet
6. Click publish to send to the fill server, or amend another (back to step 3)


XTAPI Objects
-------------------------------------------------------------------------------

TTRiskManager
TTGate
TTSODObj
TTSODSet
TTInstrObj
TTInstrNotify
TTDropHandler


Revisions
-------------------------------------------------------------------------------

Version:		1.1.0
Date Created:	04/15/2010
Notes:			None

Version:		1.2.1
Date Created:	01/17/2013
Notes:			Updated for GitHub.   Major code clean-up