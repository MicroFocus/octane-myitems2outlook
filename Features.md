Outlook Plug-in for ALM Octane Functional Spec
==============================================

# [F001]Configure the connection to workspace
------
* I clicked a "Configuration" button in the plug-in ribbon.
* A dialog is displayed.
* I enter the Octane server url, e.g. https://hackathon.almoctane.com
* I enter the user/pass.
* I click "Sign In" button.
* A message box showed signin successful or failed.
* If success, I enter the Sharespace id, e.g. 1001 by default
* I click "Show workspaces"
* A dropdown is filled with workspaces names (api/sharespaces/1001/workspaces)
* I select the workspace I'm interested and click "OK".
* The dialog is closed, information saved, current user signed out.

# [F002]Sync "My Backlog" to outlook tasks
-----
* I clicked a "Sync My Backlog" button in the plug-in ribbon.
* [P1] Outlook switches to "Tasks" module automatically.
* Retrieve my backlog data from configured Octane workspace. (entity:work_items)
* If data is not empty, Create a task category "[Octane]Backlog" if not existing.
* Refresh task in this category, meaning delete all old ones and create new ones for each work item.
* The task should contain item type and basic fields and descriptions of the work item.
** Task name = id + "-" + name in octane.
** A url at the top (and the bottom) links to the entity details in Octane.
** Show the description in the html format similar to web ui.
** [P1] comments.
** [P1] download attachments and attach them to the task.

# [F003]Sync "My Test" to outlook tasks
-----
* Similar to [F002]
* Category name: "[Octane]Test"
* Download test steps is a must. Plain Text of manual or Gherkin.

# [F004]Sync "My Run" to outlook tasks
-----
* Similar to [F002]
* Category name: "[Octane]Run"
* Download run steps is a must. [HOW to display?]

# [F005]Sync all
-----
* Sync backlog/test/run at once.

# [F006][P1]Sync one item
-----
* Able to sync one single task.
* If not existing in Octane any more, mark it as [deleted]
* If already done in Octane, mark it as [done]

# Other features
-----
* [P1] Add comments
* [P1] Move phase from outlook
