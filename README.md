# VanCupid
Dating Website (Web App) developed by using Asp.NET(MVC5).

This is the Index page of the project:

![Project Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/VanCupid.PNG)

## How ro create a project like this?

Follow the next instructions to create a Asp.Net project like this, using MVC5 and Data First.


#### Creating the Asp.Net project with MVC without Authentication:

![Step 1 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/NewProject.PNG)

![Step 2 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/MVC.PNG)

![Step 3 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/NoAuthentication.PNG)


#### Choosing a theme for your layout on Bootswatch

Go to Bootswatch website, https://bootswatch.com/ - automatic!, and choose a theme for layout. For this project, I chose *United*.

![Step 4 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/BootswatchPNG.PNG)

Copy the bootstrap.css content file to a new css file in your project. Notice that I created I file called bootstrap-united.css inside Content. Finally, in BundleConfig, determine the css file that will style your layout.

![Step 5 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/BootswatchContent.PNG)
![Step 6 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/Bundle.PNG)


#### Creating your MDF file

Now it is time to create your .mdf file and built your Database. In **App_Data**, right button to *Add* a *New Item*:

![Step 7 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/mdf.PNG)


#### Creating your EDMX file

The .edmx file will allow you to create the Controllers you need for each Table you built for your Database. In **Models**, right button to *Add* a *New Item*:

![Step 8 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/edmx1.PNG)

![Step 9 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/edmx2.PNG)

![Step 10 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/edmx3.PNG)

![Step 11 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/edmx4.PNG)

After you creat your .edmx file, built the Solution.


#### Creating the Controllers for each Database Table 

Now you have the .edmx file, you can create a Controller for each Table from your Database. In **Controllers**, right button to *Add* a *Controller*:

![Step 12 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/controller1.PNG)

![Step 13 Image](https://github.com/MarianaSouza/VanCupid/blob/master/Documentation/controller2.PNG)









