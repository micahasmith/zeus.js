/**
 * ZEUS.js Serializable Command Pattern
 * &add=0,1,2,3&0_x=1
 */
var ZEUS={
	Configuration:{
		KeySpacer:"_",
		ArgumentSpacer:"&",
		KeyValueSpacer:"=",
		IDSpacer:","
	}
};
ZEUS.Command=function() {
	this.Name='',
	this.Args=[];
};
ZEUS.Command.prototype={
	getName:function(){return this.Name;},
	getArgs:function(){return this.Args;},
	addArg:function(key,value){
		this.Args.push([key,value]);
	}
	
};
ZEUS.CommandCenter=function() {
	this.Commands=[];
};
ZEUS.CommandCenter.prototype= {
	reset:function() {
		this.Commands=[];
	},
	//group together commands by command name
	addCommand:function(c){
		var i=0,
		cs=this.Commands,
		len=cs.length,
		item={},
		found=false;
		if(len>0)
		{
			//look for sub arrays with the same command name, add to those
			for(;i<len;i+=1){
				item=cs[i];
				if(c.Name===item[0].Name) {
					cs[i].push(c);
					found=true;
				}
			}
		} else if (len===0 || !found) {
			cs.push([c]);
		}
	},
	serialize:function(c){
		var i=0,
		j=0,
		cs=this.Commands,
		len=cs.length,
		sameCommands=[],
		sameCommandsLen=0,
		item={},
		totalIter=0,
		res=[],
		getIDRange=function(start,length) {
			var ids=[];
			while(start!=length) {
				ids.push(start);
				start+=1;
			}
			return ids.join(ZEUS.Configuration.IDSpacer);
		},
		//varialbes for iterating through arguments
		cArgs=[],
		cArgsLen=0,
		cArgsIter=0,
		thisArg={};
		//loop through each command array
		for(;i<len;i+=1) {
			sameCommands=cs[i],
			sameCommandsLen=sameCommands.length,
			j=0;
			//write out the argument name and mapped ids
			res.push(ZEUS.Configuration.ArgumentSpacer);
			res.push(sameCommands[i].Name);
			res.push(ZEUS.Configuration.KeyValueSpacer);
			res.push(getIDRange(totalIter,sameCommandsLen));
			//with each command in its array
			for(;j<sameCommandsLen;j+=1) {
				cArgs=sameCommands[i].Args,
				cArgsLen=cArgs.length,
				cArgsIter=0;
				//for each argument in the command
				for(;cArgsIter<cArgsLen;cArgsIter+=1) {
					thisArg=cArgs[cArgsIter];
					res.push(ZEUS.Configuration.ArgumentSpacer);
					res.push(totalIter);
					res.push(ZEUS.Configuration.KeySpacer);
					res.push(thisArg[0]);
					res.push(ZEUS.Configuration.KeyValueSpacer);
					res.push(thisArg[1]);
				}//end loop over arguments
			}//end loop over commands of a type
		}//end loop over command arrays
		return res.join("");
	},
	toCommandString:function(c){
		
	}
};
