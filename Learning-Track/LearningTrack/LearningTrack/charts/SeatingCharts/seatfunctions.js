function getAppID(){
	var doc1 = document.URL;
	var new1 = doc1.split('/Applications/');
	var new2 = new1[1].split('/');
	return new2[0];	
}

function grade(gID, subject, assignname, score, points, studID) //this function creates the JavaScript object
{
    //PROPERTIES LISTED HERE --------------------------
        this.gradeID = gID;
        this.category = subject;
        this.assignmentName = assignname;
        this.grade = score;
        this.totalPoints=points;
        this.studentID=studID;

    //METHODS BEGIN HERE ------------------------------
}
/*===============================================================================================================*/

/*===============================================================================================================*/
function calculateAverage(array)
{
        var sum = 0;
        var average;
        for (i = 0; i < array.length; i++)
        {
                sum = sum + array[i];
        }
        average = sum / array.length;
        return average;
}

/*===============================================================================================================*/

function standardDev(array)
{
        var average = calculateAverage(array);
        var squares = new Array()
        for (i = 0; i < array.length; i++)
        {
                var temp = average - array[i];
                var pow = Math.pow(temp, 2);
                squares.push(pow);
        }
        var mean = calculateAverage(squares);
        var squareroot = Math.sqrt(mean);
        return squareroot;
}

/*===============================================================================================================*/

function studentSeat(firstname, seatnumber, id) //this function creates the JavaScript object
{
	//alert('Getting to studentSeat: ' + firstname);
    //PROPERTIES LISTED HERE --------------------------
        this.name=firstname; //1
        this.seat = seatnumber;
    	this.studentID = id; //10


}

/*===============================================================================================================*/

function studentSeatCalcs(cat, avg, standard, upp, low) //this function creates the JavaScript object
{
	this.category = cat;
	this.average = avg;
	this.standardDev = standard;
	this.upperBound = upp;
	this.lowerBound = low;
}

/*===============================================================================================================*/
function calculateGrades(grades, categories)
{
	var calculatedGrades = new Array();
	ii = 0;
	while(ii < categories.length){
		var tempcat = categories[ii].name;
		//alert('top of loop: ' + tempcat);
		var tempgrades = new Array();
		for (j = 0; j < grades.length; j++)
		{
			if (grades[j].category == tempcat)
			{
				tempgrades.push(parseFloat(grades[j].grade));
			}
		}
		var tempavg = calculateAverage(tempgrades);
		var tempstd = standardDev(tempgrades);
		var tempup = tempavg + tempstd;
		var templow = tempavg - tempstd;
		var tempobj = new studentSeatCalcs(tempcat, tempavg, tempstd, tempup, templow);
		//alert('Object category ' + tempobj.category);
		calculatedGrades.push(tempobj);
		//alert('pushed object');
		ii++;
	}
	var allGrades = new Array();
	for (ii = 0; ii < grades.length; ii++)
	{	
		allGrades.push(parseFloat(grades[ii].grade));
	}
		tempavg = calculateAverage(allGrades);
		tempstd = standardDev(allGrades);
		tempup = tempavg + tempstd;
		templow = tempavg - tempstd;
		var tempobj = new studentSeatCalcs(tempcat, tempavg, tempstd, tempup, templow);
		calculatedGrades.push(tempobj);
		return calculatedGrades;

}


/*===============================================================================================================*/
function seatcolor(id, array, grades, calculatedGrades) {
//alert ('in seat color');
        x=document.getElementById(id);  //Find the element

        var pathArray = document.URL;
        var average_pre = pathArray.split('=');
        var average = average_pre[1];
        var index = getIndex(id, array);
        var student_id=array[index].studentID;
        var studHWgrades = new Array(); //hw grades is actually any grades i that category
        var classHWgrades = new Array(); //hw grades is actually any grade in that category
        var classAllgrades = new Array();
        var studAllgrades = new Array();
        var catIndex;
        for (i = 0; i < calculatedGrades.length; i++)
        {
        	if (calculatedGrades[i].category == average)
        	{
        		catIndex = i;
        		break;
        	}
        }
        
        for (i = 0; i < grades.length; i++)
        {
                //alert('loop id: ' + grades[i].studentID + 'student id: ' + student_id);
               // if (grades[i].category == average)
                //{
                //        classHWgrades.push(parseFloat(grades[i].grade));
               // }
                if ((grades[i].category == average) && (grades[i].studentID == student_id))
                {
                        studHWgrades.push(parseFloat(grades[i].grade));
                }
                if (grades[i].studentID == student_id)
                {
                        studAllgrades.push(parseFloat(grades[i].grade));
                }
        }
        

/* CALCULATE ALL AVERAGES */
        var studHWavg = calculateAverage(studHWgrades);
        var studOverallavg = calculateAverage(studAllgrades);

if (average == 'overall')
{
        if ((studOverallavg < calculatedGrades[catIndex].average) && (studOverallavg > calculatedGrades[catIndex].lowerBound)) //below average, above lowerbound
        {
                //should be an orangish color
                //x.style.background="#E42121";
                x.style.background="#FF9900";
                x.style.color="white";
        }
        else if ((studOverallavg > calculatedGrades[catIndex].average) && (studOverallavg < calculatedGrades[catIndex].upperBound)) //above average, below upperbound
        {
                //should be yellowish green color
                //x.style.background="#006600";
                x.style.background="#33CC00";
                x.style.color="white";
        }
        else if (studOverallavg > calculatedGrades[catIndex].upperBound) //above the upperbound
        {
                x.style.background="#336600";
                x.style.color="white";
        }
        else if (studOverallavg < calculatedGrades[catIndex].lowerBound)  //below lowerbound
        {
                x.style.background="#FF3300";
                x.style.color="white";
        }
        else //default to gray if there's an issue
        {
                x.style.background="#C8C8C8";
                x.style.color="null";
        }
}
else
{
        if ((studHWavg < calculatedGrades[catIndex].average) && (studHWavg > calculatedGrades[catIndex].lowerBound)) //below average, above lowerbound
        {
                x.style.background="#FF9900";
                x.style.color="white";
        }
        else if ((studHWavg > calculatedGrades[catIndex].average) && (studHWavg < calculatedGrades[catIndex].upperBound)) //above average, below upperbound
        {
                x.style.background="#33CC00";
                x.style.color="white";
        }
        else if (studHWavg > calculatedGrades[catIndex].upperBound) //above the upperbound
        {
                x.style.background="#336600";
                x.style.color="white";
        }
        else if (studHWavg < calculatedGrades[catIndex].upperBound) //below the lowerbound
        {
                x.style.background="#FF3300";
                x.style.color="white";
        }
        else
        {
                x.style.background="#C8C8C8";
                x.style.color="null";
        }

}

}//end of seat color function

/*===============================================================================================================*/

//create function that opens up the popup if the seat isn't empty
function seatPopup(id, array)
{
        var index=getIndex(id, array);
        if (index != null)
        {
        preurl = 'highcharts/standardDev.htm?id='
        //preurl = 'student_stats.html?id=';
        url = preurl + id;
        //window.open(url,'popUpWindow','height=1000,width=980,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=0, directories=no, status=no');
        window.location.href = url;
        //window.open(url);
        }
        //window.location.href = url;
        //var e = document.getElementByI


}

/*===============================================================================================================*/

function seatName(id, array)
{
        var index = getIndex(id, array);
        if (index != null)
        {
                document.write(array[index].name);
        }
        else
        {
                document.write("<br>");
        }
}
/*===============================================================================================================*/


function isTaken(id, array)
{
        var index = getIndex(id, array);
        if (index != null)
        {
                return true;
        }
        else
        {
                return false;
        }
}


/*===============================================================================================================*/

function queryXML() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function
        var studArray = new Array(); //initiate the array for it to return
        if (window.XMLHttpRequest)
                {// code for IE7+, Firefox, Chrome, Opera, Safari
                        xmlhttp=new XMLHttpRequest(); //create xml request
                }
        else
                {// code for IE6, IE5
                        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
                }
		//NOTE: THE GUID CHANGES EVERY ITERATION OF A VERSION UPDATE (I.E. : 6.0 ->6.1)
		//45630D06-579B-4141-8D13-08087F6A8936 IS SIMULATOR
		appID = getAppID();
		var URL = '/private/var/mobile/Applications/' + appID + '/Documents/seatingChart.xml';
		//xmlhttp.open("GET","/private/var/mobile/Applications/49E7A62E-DCCA-41BC-817E-C4563E11BBF4/Documents/seatingChart.xml",false);
		xmlhttp.open("GET",URL,false);
		//xmlhttp.open("GET","/private/var/mobile/Applications/45630D06-579B-4141-8D13-08087F6A8936/Documents/seatingChart.xml",false);
		//alert('if gets here, it is opened');
		//xmlhttp.open("GET","seatingChart.xml",false);
		
                xmlhttp.send();
                xmlDoc=xmlhttp.responseXML;

                var x=xmlDoc.getElementsByTagName("SEAT");
                for (i=0;i<x.length;i++)
                {
                        //constructor for the objects
                                studArray[i]=new studentSeat(
                                x[i].getElementsByTagName("NAME")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("SEAT_NUMBER")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("STUDENT_ID")[0].childNodes[0].nodeValue
                                //x[i].getElementsByTagName("IS_CURRENT_STUDENT")[0].childNodes[0].nodeValue
                                );
                }
                return studArray;
}//end function parenthesis
/*===============================================================================================================*/

function getIndex(id, array){ //function that returns the index of where a seat element object is
        for(i=0; i<array.length; i++) {
                if(array[i].seat == id)
                {
                        return i;
                        break;
                }
}
}//end of getIndex function

/*===============================================================================================================*/

//var id = studentSeatfromURL();
//student = getStudentObject(id);
function studentSeatfromURL()
{
//this function takes the path name which was generated when a seat was clicked
//and splits it to get the correct value of the seat number
        //var pathArray = window.location.pathname;
        var pathArray = document.URL;
        var studentSeat_pre = pathArray.split('=');
        var seatnumber = studentSeat_pre[1];
        //var studentSeatNumber = pathArray[1];
        return seatnumber;
}//end of function


/*===============================================================================================================*/
function checkboxSubmit(studentsArray)
{
        var checked_array = new Array();
        var string = "?group="
        var chkbx = document.getElementsByName("group");
        var category = document.getElementsByName("category");
        var chkcount = 0;

        for (i = 0; i < chkbx.length; i++) //loop through --> THIS WILL IGNORE EMPTY SEATS
        {
                if (chkbx[i].checked == true) //if a student seat is selected
                {
                        temp = chkbx[i].value; //take the seat number and make it into a temporary variable
                        for (j = 0; j < studentsArray.length; j++) //go through each of the students in the Array of students in the classroom
                        {
                                if(temp == studentsArray[j].seat) //if that temporary variable is equal to a student's seat
                                {
                                        string += studentsArray[j].studentID + ","; //adds the student id numbers to the URL
                                }
                        }
                }
        }

        preurl = 'highcharts/standardDevGroup.htm'
        url = preurl + string;
        window.location.href = url;
}

/*===============================================================================================================*/

function checkboxSubmitGroup(studentsArray)
{

        var checked_array = new Array();
        var string = "?group="
        var chkbx = document.getElementsByName("group");
        var category = document.getElementsByName("category");
        for (i = 0; i < chkbx.length; i++) //loop through --> THIS WILL IGNORE EMPTY SEATS
        {
                if (chkbx[i].checked == true) //if a student seat is selected
                {		
                        temp = chkbx[i].value; //take the seat number and make it into a temporary variable
                        for (j = 0; j < studentsArray.length; j++) //go through each of the students in the Array of students in the classroom
                        {
                                if(temp == studentsArray[j].seat) //if that temporary variable is equal to a student's seat
                                {
                                        string += studentsArray[j].studentID + ","; //adds the student id numbers to the URL
                                }
                        }
                }
        }

        preurl = 'highcharts/standardDevGroupStudio.htm';
        url = preurl + string;
        window.location.href = url;
       
}

/*===============================================================================================================*/
function seatPopupStudio(id, array)
{
        var index=getIndex(id, array);
        if (index != null)
        {
        preurl = 'highcharts/standardDevStudio.htm?id='
        //preurl = 'student_stats.html?id=';
        url = preurl + id;
        //window.open(url,'popUpWindow','height=1000,width=980,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=0, directories=no, status=no');
        window.location.href = url;
        //window.open(url);
        }


}
