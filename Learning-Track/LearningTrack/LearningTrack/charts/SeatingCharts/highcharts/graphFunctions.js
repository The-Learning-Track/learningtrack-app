function getAppID(){
	var doc1 = document.URL;
	var new1 = doc1.split('/Applications/');
	var new2 = new1[1].split('/');
	return new2[0];	
}
/* This document will query the XML Document and correctly format the data for the high charts */

function grade(subject, assignname, score, points, studID) //this function creates the JavaScript object
{
    //PROPERTIES LISTED HERE --------------------------
	
	//this.gradeID = gID;
	this.category = subject;
	this.assignmentName = assignname;
	this.grade = score;
	this.totalPoints=points;
	this.studentID=studID;

    //METHODS BEGIN HERE ------------------------------
}
/*===============================================================================================================*/
function seatID(seatnum, idnum, first, last)
{
	this.seatnumber  = seatnum;
	this.idnumber = idnum;
	this.firstname = first;
	this.lastname = last;
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
        squareroot = squareroot.toFixed(2);
        return squareroot;
}
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
        average = average.toFixed(2);
        return average;
}
/*===============================================================================================================*/
function GetGrades() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function
	
	var studArray = new Array(); //initiat;e the array for it to return
	if (window.XMLHttpRequest)
		{// code for IE7+, Firefox, Chrome, Opera, Safari
			xmlhttp=new XMLHttpRequest(); //create xml request
		}
	else
		{// code for IE6, IE5
			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
		}
		//45630D06-579B-4141-8D13-08087F6A8936 IS SIMULATOR
		appID = getAppID();
		var URL = '/private/var/mobile/Applications/' + appID + '/Documents/courseGrades.xml';
 		xmlhttp.open("GET",URL,false);
 		//xmlhttp.open("GET","/private/var/mobile/Applications/45630D06-579B-4141-8D13-08087F6A8936/Documents/courseGrades.xml",false);
		//xmlhttp.open("GET","courseGrades.xml",false);
		xmlhttp.send();
		xmlDoc=xmlhttp.responseXML; 
		var x=xmlDoc.getElementsByTagName("Grade");
		//var y=xmlDoc.getElementsByTagName("seatLocation")[1].childNodes[0].nodeValue;
		for (i=0;i<x.length;i++)
		{ 	
			//constructor for the objects that represent whether a seat is taken
				studArray[i]=new grade(
				//x[i].getElementsByTagName("ID")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("category")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("assignmentName")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("score")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("totalPoints")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("studentID")[0].childNodes[0].nodeValue
				);
					
		}



	return studArray;
	
		
}//end function parenthesis
/*===============================================================================================================*/
function GetSeats() //this function will query the appropriate XML file and return the array of JavaScript objects
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
 		
 		//45630D06-579B-4141-8D13-08087F6A8936 IS SIMULATOR
 		ppID = getAppID();
		var URL = '/private/var/mobile/Applications/' + appID + '/Documents/courseGrades.xml';
 		xmlhttp.open("GET",URL,false);
 		//xmlhttp.open("GET","/private/var/mobile/Applications/45630D06-579B-4141-8D13-08087F6A8936/Documents/courseGrades.xml",false);
		//xmlhttp.open("GET","courseGrades.xml",false);
		xmlhttp.send();
		xmlDoc=xmlhttp.responseXML; 
		var x=xmlDoc.getElementsByTagName("Student");
		
		for (i=0;i<x.length;i++)
		{ 	
			//constructor for the objects that represent whether a seat is taken
				studArray[i]=new seatID(
				x[i].getElementsByTagName("seatLocation")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("studentID")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("firstName")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("lastName")[0].childNodes[0].nodeValue
				);
					
		}
		

	return studArray;
	
		
}//end function parenthesis

/*===============================================================================================================*/

/*===============================================================================================================*/
function FilterGrades(id, category, array)
{
	var filteredArray = new Array();
	var j = 0;
	for (var i = 0; i < array.length; i++)
	{
		if (array[i].studentID == id && array[i].category == category)
		{
			filteredArray[j]= array[i];
			j++;
		}
	}
	return filteredArray;
}
/*===============================================================================================================*/
function FindSeat(seatnum, array)
{
	var IDnum;
	for (var i = 0; i < array.length; i++)
	{
		if (array[i].seatnumber == seatnum)
		{
			IDnum = array[i].idnumber;
		}
	}
	return IDnum;
}
/*===============================================================================================================*/
function getNumbers(array)
{
	var numArray = new Array();
	for (var i = 0; i < array.length; i++)
	{
		numArray[i]=parseFloat(array[i].grade)
	}
	return numArray;
}

/*===============================================================================================================*/

function Category(cat_name, stdev, avg)
{
	this.name = cat_name;
	this.std = stdev;
	this.average = avg;

}

/*===============================================================================================================*/

function Assignments(name, standard_dev, avg, total_points, cat, maximum, minimum)
{
	this.name = name;
	this.std = standard_dev;
	this.average = avg;
	this.points = total_points;
	this.category = cat;
	this.max = maximum;
	this.min = minimum;
}

/*===============================================================================================================*/

function AssignmentsNames(assignment_Array, categoryname)
{
	var array = new Array();
	for (i = 0; i < assignment_Array.length; i++)
	{
		if (assignment_Array[i].category == categoryname){
		array.push(assignment_Array[i].name);}
	}
	return array;
}

/*===============================================================================================================*/

function GetCategory() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function
	var categoryArray = new Array(); //initiate the array for it to return
	if (window.XMLHttpRequest)
		{// code for IE7+, Firefox, Chrome, Opera, Safari
			xmlhttp=new XMLHttpRequest(); //create xml request
		}
	else
		{// code for IE6, IE5
			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
		}
		//45630D06-579B-4141-8D13-08087F6A8936 IS SIMULATOR
		appID = getAppID();
		var URL = '/private/var/mobile/Applications/' + appID + '/Documents/courseAverages.xml';
 		xmlhttp.open("GET",URL,false);
 		//xmlhttp.open("GET","/private/var/mobile/Applications/45630D06-579B-4141-8D13-08087F6A8936/Documents/courseAverages.xml",false);
		//xmlhttp.open("GET","courseAverages.xml",false);
		xmlhttp.send();
		xmlDoc=xmlhttp.responseXML; 
		var x=xmlDoc.getElementsByTagName("CATEGORY");
		//var y=xmlDoc.getElementsByTagName("seatLocation")[1].childNodes[0].nodeValue;
		for (i=0;i<x.length;i++)
		{ 	
			//constructor for the objects that represent whether a seat is taken
				categoryArray[i]=new Category(
				x[i].getElementsByTagName("categoryName")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("categoryStandardDev")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("categoryAverage")[0].childNodes[0].nodeValue
				);
					
		}

			

	return categoryArray;
		
		
}//end function parenthesis

/*===============================================================================================================*/

function GetAssignment() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function

	var assignmentArray = new Array(); //initiate the array for it to return
	if (window.XMLHttpRequest)
		{// code for IE7+, Firefox, Chrome, Opera, Safari
			xmlhttp=new XMLHttpRequest(); //create xml request
		}
	else
		{// code for IE6, IE5
			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
		}
		//45630D06-579B-4141-8D13-08087F6A8936 IS SIMULATOR
		appID = getAppID();
		var URL = '/private/var/mobile/Applications/' + appID + '/Documents/courseAverages.xml';
 		xmlhttp.open("GET",URL,false);
		//xmlhttp.open("GET","/private/var/mobile/Applications/45630D06-579B-4141-8D13-08087F6A8936/Documents/courseAverages.xml",false);
		//xmlhttp.open("GET","courseAverages.xml",false);
		xmlhttp.send();
		xmlDoc=xmlhttp.responseXML; 
		var x=xmlDoc.getElementsByTagName("ASSIGNMENT");
		for (i=0;i<x.length;i++)
		{ 	
			//constructor for the objects that represent whether a seat is taken
				assignmentArray[i]=new Assignments(
				x[i].getElementsByTagName("assignmentName")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("assignmentStandardDev")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("assignmentAverage")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("totalPoints")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("assignmentCategory")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("assignmentMax")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("assignmentMin")[0].childNodes[0].nodeValue
				);
					
		}

	return assignmentArray;
		
}//end function parenthesis


/*===============================================================================================================*/

function PlotObject(cat, grades, names, ttl, x, y, sub) //this will be the object that will store all the necessary info for the standardDev graph
{//begin function
	this.category = cat;
	this.dataArray = grades;
	this.nameArray = names;
	this.title = ttl;
	this.xAxis = x;
	this.yAxis = y;
	this.subtitle = sub;
	

} //end function

/*===============================================================================================================*/

function createPlotObject(assignmentArray, category, studArray, studID)//was studID
{

	var cat = category;
	var dataArray = new Array();
	var namesArray = new Array();
	var studentGrade;
	for (i = 0; i < assignmentArray.length; i++)
	{
		if (assignmentArray[i].category == category)
		{
			//[MIN, -STD, STUDENTSCORE, +STD, MAX, AVERAGE]
			for (j = 0; j < studArray.length; j++)
			{
				if ((studArray[j].assignmentName == assignmentArray[i].name) && (studArray[j].studentID == studID))
				{
					studentGrade = parseFloat(studArray[j].grade);
					
					break;
				}
				else
				{
					studentGrade = null;
				}
			}
			var temp = new Array(); //temporary array to push onto the dataArray()
			namesArray.push(assignmentArray[i].name); //add the name of the assignment to the namesArray
			var std = parseFloat(assignmentArray[i].std);
			var avg = parseFloat(assignmentArray[i].average);
			var min = parseFloat(assignmentArray[i].min);
			var max = parseFloat(assignmentArray[i].max);
			var neg = avg - std;
			var pos = avg + std;
			temp = [min, neg.toFixed(2), studentGrade, pos.toFixed(2), max, avg.toFixed(2)];
			dataArray.push(temp);
		}
	}
	title = 'Performance in ' + category;
	xaxis = "Assignment Names";
	yaxis = "Scores";
	subtitle = "By point values";
	
	plotobject = new PlotObject(cat, dataArray, namesArray, title, xaxis, yaxis, subtitle);
	return plotobject;
}


/*===============================================================================================================*/


function GroupGrades(grades)
{
	//alert(grades[0].assignmentName);
}
/*===============================================================================================================*/

function groupassignments(name, gradeArray)
{
	this.name = name;
	this.gradeArray = gradeArray;

}
/*===============================================================================================================*/

/*===============================================================================================================*/

function calculateGroups(id_array, category, gradeArray, getAssignments, studentID)
{

	var assignmentNames = new Array();
	var maxGrades = new Array();
	var minGrades = new Array();
	/* Loop through each getAssignments, and if that category equals the category inputted, add assignment name to an array */
	for (i = 0; i < getAssignments.length; i++)
	{
		if (getAssignments[i].category == category)
		{
			assignmentNames.push(getAssignments[i].name);
		}
	}
	
	var individGradeArray = new Array();
	/* GET PARTICULAR STUDENT'S SCORE */
	for (j = 0; j < assignmentNames.length; j++)
	{
		tempname = assignmentNames[j];
		for (i = 0; i < gradeArray.length; i++)
		{
			//
			if ((gradeArray[i].assignmentName == tempname) && (gradeArray[i].studentID == studentID))
			{
				individGradeArray.push(gradeArray[i].grade);
				
			}
		}
	}
	
	
	
	//create array to store the appropriate grades
	var groupassignment = new Array();
	
	/* Loop through each assignment name.
	/* If a student id in the id_array equals that in the grade array, AND the assignment name = the assignment name
	/* from the assignment Names array, push the object on 
	*/
	for (j=0; j < assignmentNames.length; j++) //begin looping through assignments name
	{
		var temp_assignment = assignmentNames[j];
		var temp_grade_array = new Array();
		//loop through id_array	
			for (k = 0; k < id_array.length-1; k++)
			{
				temp_id = id_array[k];
				//loop through grade Array
					for (l = 0; l < gradeArray.length; l++)
					{
						if ((gradeArray[l].studentID == temp_id) && gradeArray[l].assignmentName == temp_assignment)
						{
							temp_grade_array.push(gradeArray[l].grade);	
						}
					}
				
			}
			groupassignment.push(temp_grade_array); //push the array of grades for that particular assignment into array
			maxGrades.push(Math.max.apply(null, temp_grade_array));
			minGrades.push(Math.min.apply(null, temp_grade_array));
	}
	
	/* GROUPASSIGNMENT IS AN ARRAY OF AN ARRAY OF GRADES FOR EACH ASSIGNMENT NAME */
	
	var average = new Array();
	/* NOW MUST CALCULATE THE AVERAGE OF EACH ONE */
	for (i = 0; i < groupassignment.length; i++)
	{
		var sum = 0;
		var temp_length;
		for (j = 0; j < groupassignment[i].length; j++)
		{
			sum = sum + parseFloat((groupassignment[i][j]));
			temp_length = groupassignment[i].length;
		}
		var temp_average = sum / temp_length;
		average.push(temp_average);
	}

	
	/* ====== CALCULATE THE STANDARD DEVIATION ======== */
	var standard_dev = new Array();
	
	for (i = 0; i < groupassignment.length; i++)
	{
		var temp_avg = average[i];
		var temp_new_avg = new Array();
		var temp_sum = 0;
		var tempsqrt;
		for (j = 0; j < groupassignment[i].length; j++)
		{
			var temp = parseFloat(groupassignment[i][j]) - temp_avg;
			var pow = Math.pow(temp, 2);
			temp_new_avg.push(pow);
			
		}
		for (k = 0; k < temp_new_avg.length; k++)
		{
			temp_sum = temp_sum + temp_new_avg[k];
		}
		temp_sum = temp_sum / groupassignment[i].length;;
		tempsqrt = Math.sqrt(temp_sum);
		standard_dev.push(tempsqrt);
	}

	var dataArray = new Array();
	for (i = 0; i < groupassignment.length; i++)
	{
		var neg_temp = average[i] - standard_dev[i];
		neg_temp = neg_temp.toFixed(2);
		var pos_temp = average[i] + standard_dev[i];

		pos_temp = pos_temp.toFixed(2);
		average_tmp = parseFloat(average[i]);
		average_tmp = average_tmp.toFixed(2);
		var temparray = [parseFloat(minGrades[i]), neg_temp, parseFloat(individGradeArray[i]), pos_temp, parseFloat(maxGrades[i]), average_tmp];
		dataArray.push(temparray);
	}
	
	title = 'Performance in ' + category;
	xaxis = 'Assignment Names';
	subtitle = 'By points earned';
	yaxis = 'Scores';
	
	plotobject = new PlotObject(category, dataArray, assignmentNames, title, xaxis, yaxis, subtitle);
	return plotobject;
}



/*===============================================================================================================*/

function getCategoryID() {
	var pathArray = document.URL;
	var index = pathArray.indexOf('cat=');
	if (index != -1)
	{
	average = pathArray[index + 4];
	}
	else
	{
		average = 0;
	}
	if (average == null || average == undefined)
	{
		average = 0;
	}
	return average;
}         //Change the style

/*===============================================================================================================*/

function getStudentID() {

	var pathArray = document.URL;
	var average;
	var average_pre = pathArray.split('?student=');
	if (average_pre.length > 2)
	{
		average_pre = average_pre.split('?cat=');
		average=average_pre[0];
	}
	else{
		average = average_pre[1];
	}
	if (average == null || average == undefined)
	{
		average = 0;
	}
	return average;
}  


function getStudentID2() {

	var pathArray = document.URL;
	var average;
	var average_pre = pathArray.split('?');
	if (average_pre.length > 2)
	{
		average_pre = pathArray.split('?id=');
		average_pre=average_pre[1].split('?cat=');
		average=average_pre[0];
	}
	else{
		average_pre=pathArray.split('?id=');
		average = average_pre[1];
	}
	if (average == null || average == undefined)
	{
		average = 0;
	}
	return average;
}  

/*===============================================================================================================*/

function changeCategory()
{
		var myselect = document.getElementById("sample");
		var category = myselect.options.selectedIndex;
		return category;
}	

/*===============================================================================================================*/
function goBack()
{
	window.history.back();
}

/*===============================================================================================================*/

//================================================================================
function overallGroupStats(student_ID, student_ID_array)
{

	//gradeArray is from courseGrades, so overall all of the grades
	//getAssignments is from courseAverages xml, which is all the assignments
	//=========================step 1 ========================================
	var category_Array = GetCategory();
	var category_Names = new Array();
	for (i = 0; i < category_Array.length; i++)
	{	
		category_Names.push(category_Array[i].name);
	}
	
	//=========================step 2 ========================================
	//add up total points for each individual subject
	var assignment_Array = GetAssignment(); //gets assignments
	var totalpoints = new Array(); //store the total amount of points in each category
	var amountOfAssignments = new Array(); //store the amount of assignments in each category
	var scalefactor = new Array(); //store the scale factor for each assignment
	for (i = 0; i < category_Names.length; i++)
	{
		tempname = category_Names[i];
		var temp_sum_points = 0;
		var assignmentCount = 0;
		for (j = 0; j < assignment_Array.length; j++)
		{
			if (assignment_Array[j].category == tempname)
			{
				temp_sum_points = temp_sum_points + parseFloat(assignment_Array[j].points);
				assignmentCount++;
			}
		}
		totalpoints.push(temp_sum_points);
		amountOfAssignments.push(assignmentCount);
	}
	
	//=========================step 3 ========================================
	//loop through and find all the grades according to each category
	//and then average them together, store them in an array
	var all_grades_pre = GetGrades();
	var all_grades = new Array();
	for(ii = 0; ii < student_ID_array.length-1; ii++)
	{
		temp_stud_ID= student_ID_array[ii];
		for (jj = 0; jj< all_grades_pre.length; jj++)
		{
			if (all_grades_pre[jj].studentID == temp_stud_ID)
			{
				all_grades.push(all_grades_pre[jj]);
			}
		}
	}
	
	var averages = new Array(); //will store the averages for each category
	var conversion_factor;
	for (i = 0; i < category_Names.length; i++)
	{
		var tempname = category_Names[i];
		var tempsum = 0;
		var average = 0;
		var divisor = 0;
		for (j = 0; j < all_grades.length; j++)
		{
			if (all_grades[j].category == tempname)
			{
				conversion_factor = 100 / parseFloat(all_grades[j].totalPoints);
				tempsum = tempsum + (parseFloat(all_grades[j].grade) * conversion_factor);
				divisor++;
			}	
		}	
		average = tempsum / divisor;
		averages.push(average);
	}
	//=========================step 4 ========================================
	//must calculate each student's average and find the minimum and the maximum
	//begin by looping through all the grades and getting each student's id
	
	var categoryMax = new Array();
	var categoryMin = new Array();
	var studentIDs = GetSeats();
	var STDev = new Array();
	var standard_dev = new Array();
	for (i = 0; i < category_Names.length; i++)
	{
		var studentAverages = new Array();
		var temp_category = category_Names[i];
		for (j = 0; j < student_ID_array.length-1; j++)
		{
			var temp_sum_1 = 0;
			var temp_count = 0;
			var tempaverage;
			var temp_id = student_ID_array[j];
			for (k = 0; k < all_grades.length; k++)
			{
				if ((all_grades[k].studentID == temp_id) && (all_grades[k].category == temp_category))
				{
					conversion_factor = 100 / parseFloat(all_grades[k].totalPoints);
					temp_sum_1 = temp_sum_1 + (parseFloat(all_grades[k].grade) * conversion_factor);
					//alert('total points: ' + all_grades[k].totalPoints + 'student grade: ' + all_grades[k].grade + 'conversion factor: ' + conversion_factor);
					temp_count++;
				}
			}
			temp_average = temp_sum_1 / temp_count;
			temp_average=temp_average.toFixed(2);
			studentAverages.push(temp_average);
		}//end of j loop
		categoryMax.push(Math.max.apply(null, studentAverages));
		categoryMin.push(Math.min.apply(null, studentAverages));
		
		/* CALCULATE THE STANDARD DEVIATION============================================== */
		var average_temporary = averages[i];
		var temp_stdevs = new Array();
		var subtract_temp;
		var tempsqrt;
		for (kk = 0; kk < studentAverages.length; kk++)
		{
			subtract_temp = studentAverages[kk] - average_temporary;
			var pow = Math.pow(subtract_temp, 2);
			temp_stdevs.push(pow);
		}
		
		var tempstd_sum = 0;
		for (kk = 0; kk < temp_stdevs.length; kk++)
		{
			tempstd_sum = tempstd_sum + temp_stdevs[kk];
		}
		tempstd_sum = tempstd_sum / studentAverages.length;
		tempsqrt = Math.sqrt(tempstd_sum);
		standard_dev.push(tempsqrt);


	} //end of i loop
	
	//=====================FIND PARTICULAR STUDENT'S AVERAGE================================
	var temp_stud_average = 0; 
	var temp_avg_count = 0;
	var student_Averages = new Array();

	for (jj = 0; jj < category_Names.length; jj++)
	{
		var temp_avg_count = 0;
		var temp_stud_average = 0; 
		var tempcat = category_Names[jj];
		for (ii = 0; ii < all_grades.length; ii++)
		{
			if ((all_grades[ii].studentID == student_ID) && (all_grades[ii].category == tempcat))
			{
				var multiplier = 100 / parseFloat(all_grades[ii].totalPoints);
				//alert(multiplier);
				temp_stud_average = temp_stud_average + (parseFloat(all_grades[ii].grade)*multiplier);
				//alert('total points: ' + all_grades[ii].totalPoints + 'student grade: ' + all_grades[ii].grade + 'conversion factor: ' + multiplier);
				temp_avg_count++;
				}
		}
		var finalstudentavg = temp_stud_average / temp_avg_count;
		student_Averages.push(finalstudentavg);
		
	}//end of jj loop
	//var finalstudentavg = temp_stud_average / temp_avg_count;
	//=====================CREATE OVERALL PERCENTAGE================================



	var dataArray = new Array();
	//=========================step 5 ========================================
	//=====================CREATE PLOT OBJECTS================================
	for (i = 0; i < category_Array.length; i++)
	{
		var neg_temp = averages[i] - standard_dev[i];
		neg_temp = neg_temp.toFixed(2);
		var pos_temp = averages[i] + standard_dev[i];
		pos_temp = pos_temp.toFixed(2);
		stud_avg_temp = student_Averages[i];
		all_avgs_temp = averages[i];
		var temparray = [categoryMin[i], neg_temp, stud_avg_temp.toFixed(2), pos_temp, categoryMax[i], all_avgs_temp.toFixed(2)];
		dataArray.push(temparray);
	}
	var title = 'Overall';
		title2 = 'Overall Performance';
	xaxis = "Category";
	yaxis = "Percentage";
	subtitle = "By percentage of points earned in each category";
	plotobject = new PlotObject(title, dataArray, category_Names, title2, xaxis, yaxis, subtitle);
	return plotobject;
	
}

/*===============================================================================================================*/




function overallGroupStatsStudent(student_ID, student_ID_array)
{

	//gradeArray is from courseGrades, so overall all of the grades
	//getAssignments is from courseAverages xml, which is all the assignments
	//=========================step 1 ========================================
	var category_Array = GetCategory();
	var category_Names = new Array();
	for (i = 0; i < category_Array.length; i++)
	{	
		category_Names.push(category_Array[i].name);
	}
	
	//=========================step 2 ========================================
	//add up total points for each individual subject
	var assignment_Array = GetAssignment(); //gets assignments
	var totalpoints = new Array(); //store the total amount of points in each category
	var amountOfAssignments = new Array(); //store the amount of assignments in each category
	var scalefactor = new Array(); //store the scale factor for each assignment
	for (i = 0; i < category_Names.length; i++)
	{
		tempname = category_Names[i];
		var temp_sum_points = 0;
		var assignmentCount = 0;
		for (j = 0; j < assignment_Array.length; j++)
		{
			if (assignment_Array[j].category == tempname)
			{
				temp_sum_points = temp_sum_points + parseFloat(assignment_Array[j].points);
				assignmentCount++;
			}
		}
		totalpoints.push(temp_sum_points);
		amountOfAssignments.push(assignmentCount);
	}
	
	//=========================step 3 ========================================
	//loop through and find all the grades according to each category
	//and then average them together, store them in an array
	var all_grades_pre = GetGrades();
	var all_grades = new Array();
	for(ii = 0; ii < student_ID_array.length-1; ii++)
	{
		temp_stud_ID= student_ID_array[ii];
		for (jj = 0; jj< all_grades_pre.length; jj++)
		{
			if (all_grades_pre[jj].studentID == temp_stud_ID)
			{
				all_grades.push(all_grades_pre[jj]);
			}
		}
	}
	
	var averages = new Array(); //will store the averages for each category
	var conversion_factor;
	for (i = 0; i < category_Names.length; i++)
	{
		var tempname = category_Names[i];
		var tempsum = 0;
		var average = 0;
		var divisor = 0;
		for (j = 0; j < all_grades.length; j++)
		{
			if (all_grades[j].category == tempname)
			{
				conversion_factor = 100 / parseFloat(all_grades[j].totalPoints);
				tempsum = tempsum + (parseFloat(all_grades[j].grade) * conversion_factor);
				divisor++;
			}	
		}	
		average = tempsum / divisor;
		averages.push(average);
	}
	//=========================step 4 ========================================
	//must calculate each student's average and find the minimum and the maximum
	//begin by looping through all the grades and getting each student's id
	
	var categoryMax = new Array();
	var categoryMin = new Array();
	var studentIDs = GetSeats();
	var STDev = new Array();
	var standard_dev = new Array();
	for (i = 0; i < category_Names.length; i++)
	{
		var studentAverages = new Array();
		var temp_category = category_Names[i];
		for (j = 0; j < student_ID_array.length-1; j++)
		{
			var temp_sum_1 = 0;
			var temp_count = 0;
			var tempaverage;
			var temp_id = student_ID_array[j];
			for (k = 0; k < all_grades.length; k++)
			{
				if ((all_grades[k].studentID == temp_id) && (all_grades[k].category == temp_category))
				{
					conversion_factor = 100 / parseFloat(all_grades[k].totalPoints);
					temp_sum_1 = temp_sum_1 + (parseFloat(all_grades[k].grade) * conversion_factor);
					temp_count++;
				}
			}
			temp_average = temp_sum_1 / temp_count;
			temp_average=temp_average.toFixed(2);
			studentAverages.push(temp_average);
		}//end of j loop
		categoryMax.push(Math.max.apply(null, studentAverages));
		categoryMin.push(Math.min.apply(null, studentAverages));
		
		/* CALCULATE THE STANDARD DEVIATION============================================== */
		var average_temporary = averages[i];
		var temp_stdevs = new Array();
		var subtract_temp;
		var tempsqrt;
		for (kk = 0; kk < studentAverages.length; kk++)
		{
			subtract_temp = studentAverages[kk] - average_temporary;
			var pow = Math.pow(subtract_temp, 2);
			temp_stdevs.push(pow);
		}
		
		var tempstd_sum = 0;
		for (kk = 0; kk < temp_stdevs.length; kk++)
		{
			tempstd_sum = tempstd_sum + temp_stdevs[kk];
		}
		tempstd_sum = tempstd_sum / studentAverages.length;
		tempsqrt = Math.sqrt(tempstd_sum);
		standard_dev.push(tempsqrt);


	} //end of i loop
	
	//=====================FIND PARTICULAR STUDENT'S AVERAGE================================
	var temp_stud_average = 0; 
	var temp_avg_count = 0;
	var student_Averages = new Array();

	for (jj = 0; jj < category_Names.length; jj++)
	{
		var temp_avg_count = 0;
		var temp_stud_average = 0; 
		var tempcat = category_Names[jj];
		for (ii = 0; ii < all_grades_pre.length; ii++)
		{
			if ((all_grades_pre[ii].studentID == student_ID) && (all_grades_pre[ii].category == tempcat))
			{
				var multiplier = 100 / parseFloat(all_grades_pre[ii].totalPoints);
				temp_stud_average = temp_stud_average + (parseFloat(all_grades_pre[ii].grade)*multiplier);
				//alert('assignment name: ' + all_grades_pre[ii].assignmentName + ' total points: ' + all_grades_pre[ii].totalPoints + ' student grade: ' + all_grades_pre[ii].grade + ' conversion factor: ' + multiplier);
				temp_avg_count++;
				}
		}
		var finalstudentavg = temp_stud_average / temp_avg_count;
		student_Averages.push(finalstudentavg);
	}//end of jj loop
	//var finalstudentavg = temp_stud_average / temp_avg_count;
	//=====================CREATE OVERALL PERCENTAGE================================



	var dataArray = new Array();
	//=========================step 5 ========================================
	//=====================CREATE PLOT OBJECTS================================
	for (i = 0; i < category_Array.length; i++)
	{
		//
		var neg_temp = averages[i] - standard_dev[i];
		neg_temp = neg_temp.toFixed(2);
		var pos_temp = averages[i] + standard_dev[i];
		pos_temp = pos_temp.toFixed(2);
		var temparray = [categoryMin[i], neg_temp, student_Averages[i].toFixed(2), pos_temp, categoryMax[i], averages[i].toFixed(2)];
		dataArray.push(temparray);
	}
	var title = 'Overall';
		title2 = 'Overall Performance';
	xaxis = "Category";
	yaxis = "Percentage";
	subtitle = "By percentage of points earned in each category";
	plotobject = new PlotObject(title, dataArray, category_Names, title2, xaxis, yaxis, subtitle);
	return plotobject;
	
}

//====================================================================

function getGroupFromURL(theURL)
{
    var URL2=theURL.split('?group=');
    URL2=URL2[1].split('?cat=');
    return URL2[0];
}
//====================================================================
function getCatFromURL(theURL)
{
    var URL2 = theURL.split('?cat=');
    var URL2 = URL2[1].split('?student=');
    return URL2[0];
}
//====================================================================
function getRawURL(theURL)
{
    URL2=theURL.split('?');
    return URL2[0];
}
//====================================================================
function getStudentIDURL(theURL)
{
    URL2 = theURL.split('?student=');
    return URL2[1];
}