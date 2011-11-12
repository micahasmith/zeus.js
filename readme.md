# zeus.js

As stated in the description, zeus.js is a querystring serializable command/query pattern. It was made with analytics use in mind.

## Basic Usage

Lets take a look at the two objects that make up Zeus-- the Command and the CommandCenter.

### Command

A Command is a simple object with two properties-- Name and the Args array. The args array is a string based dictionary-like object. Example:

	var command = new ZEUS.Command();
	//set the command name
	command.Name="add";
	//add two different arguments
	command.addArg("num1","3");
	command.addArg("num2","5");

### CommandCenter

The CommandCenter object aggregates the commands and also performs serialization. Example:

	var command = new ZEUS.Command();
	//set the command name
	command.Name="add";
	//add two different arguments
	command.addArg("num1","3");
	command.addArg("num2","5");
	
	var center - new ZEUS.Command();
	center.addCommand(command);
	console.log(center.serialize);
	//would now output &add=0&0_num1=3&0_num2=5
	
### Serialization Syntax

During the serialization process, commands get grouped together and assigned an identity. Using the example above this is noticable-- the add command was assigned an id of 0.

Arguments take on the form of id_key=value--that is why after the add=0 id assignment we saw 0_num1=3; the add command with an id of 0 had a num1 argument of 3. 

## Configuration

Spacers are settable on a global level. The defaults are set to querystring workable values. See ZEUS.Configuration in zeus.js.
