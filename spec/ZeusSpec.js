describe("ZEUS.Command", function() {
  var command;
  
  beforeEach(function() {
    command= new ZEUS.Command();
  });

  it("should be accessible", function() {
    expect(typeof command).toNotEqual("undefined");

  });
  it("should have a name setting",function(){
  	expect(command.Name).toEqual("");
  	
  });
  it("should have an arguments setting",function(){
  	expect(command.Args).toEqual([]);
  	
  });
  it("should be able to store key value params",function(){
  	command.addArg("mykey","myvalue");
  	expect(command.Args[0][0]).toEqual("mykey");
  	expect(command.Args[0][1]).toEqual("myvalue");
  	
  });
  
});

describe("ZEUS.CommandCenter",function() {
	var center,command;
	beforeEach(function() {
		center = new ZEUS.CommandCenter();
		command = new ZEUS.Command();
	});
	describe("when commands are added",function(){
	
		it("should allow you to add commands",function() {
			center.addCommand(command);
			expect(center.Commands.length).toEqual(1);
			
		});
		it("should combine same-named commands together",function(){
			var command2= new ZEUS.Command();
			command.Name="name";
			command.addArg("k","v");
			command2.Name="name";
			command2.addArg("k","v");
			center.addCommand(command);
			center.addCommand(command2);
			expect(center.Commands.length).toEqual(1);
			expect(center.Commands[0].length).toEqual(2);
			
		});
	
	});
	describe("when it serializes",function(){
		beforeEach(function(){
			center.reset();
		});
		it("should return an empty string when nothing was added",function(){
			expect(center.serialize()).toEqual("");
		});
		it("should serialize one command correctly",function(){
			command.Name="test";
			command.Args.push(["arg1key","arg1value"]);
			center.addCommand(command);
			expect(center.serialize()).toEqual("&test=0&0_arg1key=arg1value");
		});
		it("should serialze two different commands correctly",function(){
			var command2= new ZEUS.Command();
			command.Name="test";
			command.Args.push(["arg1key","arg1value"]);
			center.addCommand(command);
			
			command2.Name="test2";
			command.Args.push(["arg1key","arg1value"]);
			expect(center.serialize()).toEqual("&test=0&0_arg1key=arg1value&test2=1&1_arg1key=arg1value");
		});
	});
});
