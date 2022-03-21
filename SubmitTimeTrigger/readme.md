
follow the below steps to publish azure function : -

Right Click on project inside visual studio
choose publish to azure cloud
create new azure function (choose subscription, resource group, plan type and location)
click create
after azure function created, click finish
configure application insights for tracking app
once all configuration is done
click publish

you can test function using the following link : https://submittimetrigger.scm.azurewebsites.net/TimeFunction
use body json : 
{
    StartOn:"10/10/2020",
    EndOn:"10/10/2020"
}

github link : https://github.com/a-albehwar/SubmitTimeTrigger