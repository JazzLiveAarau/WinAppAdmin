// File: JazzProgramm.js
//
// Description:
// Utility functions for the display of concert data on the website
//
// Folders:
// This file is on the JAZZ live AARAU server in the folder: 
// appadmin/JazzAppAdmin/HtmVorlagen
// This file is in the computer in the folder: 
// C:\Development\JazzAppAdmin
//
// Use of the file:
// The content is added to the (this) file JazzProgramm_Aktuell_Naechste.js
// The windows application JAZZ live AARAU Admin adds the content with 
// function Webpage->Homepage und Intranet aktalisieren.
//
// Remark:
// It is necessary that the objects with the concert data and these functions,
// using the objects, are in the same file. It works with separate files
// in the computer (file system) but not on the server.
//
// Revisions:
// 2017-02-13 Originally written
// 2017-12-09 New scripts for JazzProgramm.htm
// 2018-05-05 New format for day and month (ConcertMonthIntToName)

// Returns a string for a small poster image
function ImgSmallPoster(i_path_photo)
{
  return  "<img src=" + "'" + i_path_photo 
		  + "'" + " alt=" + "'" + "Plakat" +"'" 
		  + " width=" + "'" + "80" + "'" + " >"	 ;
}  // ImgSmallPoster

// Returns a string for a small concert poster image
function ImgSmallPosterConcert(i_path_photo)
{
  return  "<img src=" + "'" + "../" + i_path_photo 
		  + "'" + " alt=" + "'" + "Plakat" +"'" 
		  + " width=" + "'" + "80" + "'" + " >"	 ;
}  // ImgSmallPosterConcert

// Returns a string for a small concert poster image
function ImgPosterConcert(i_path_photo)
{
  return  "<img src=" + "'" + "../" + i_path_photo 
		  + "'" + " alt=" + "'" + "Plakat" +"'" 
		  + " width=" + "'" + "380" + "'" + " >"	 ;
}  // ImgPosterConcert


// Returns true if date is passed
function DateIsPassed(i_concert_year, i_concert_month, i_concert_day)
{
	var ret_boolean = true;
	
	var i_concert_year_int = parseInt(i_concert_year);
	var i_concert_month_int = parseInt(i_concert_month);
	var i_concert_day_int = parseInt(i_concert_day);
	
	var current_date = new Date();
    var current_year = current_date.getFullYear();
	var current_month = current_date.getMonth() + 1;
	var current_day = current_date.getDate();
	
	if (current_year >  i_concert_year_int )
	{
		return ret_boolean;
	}
	else if (current_year ==  i_concert_year_int && current_month > i_concert_month_int)
	{
		return ret_boolean;
	}
	else if (current_year ==  i_concert_year_int && current_month == i_concert_month_int && current_day > i_concert_day_int)
	{
		return ret_boolean;
	}
	
	ret_boolean = false;
	
	return ret_boolean;
	
}  // DateIsPassed

// Returns a string for the date and time of the concert
function ConcertDayDateTimePriorDate(i_day_name, i_concert_year, i_concert_month, i_concert_day, i_start_hour, i_start_minute)
{
	ret_str = "";
	
	ret_str = ret_str + i_concert_day + "/" + i_concert_month + "<br>" + "<br>";
	
	var ret_boolean = DateIsPassed(i_concert_year, i_concert_month, i_concert_day);
	if (ret_boolean == true)
		return ret_str;

	ret_str = ConcertDayDateTime(i_day_name, i_concert_year, i_concert_month, i_concert_day, i_start_hour, i_start_minute);
	
	return ret_str;
	
} // ConcertDayDateTimePriorDate


// Returns a string for the date and time of the concert
function ConcertDayDateTime(i_day_name, i_concert_year, i_concert_month, i_concert_day, i_start_hour, i_start_minute)
{
	ret_str = "";
	
	ret_str = ret_str + i_day_name + "<br>";
	
	ret_str = ret_str + i_concert_day + ". " + ConcertMonthIntToName(i_concert_month) + "<br>";
	
	ret_str = ret_str + i_start_hour + ":" + i_start_minute + " h";
	
	return ret_str;
	
} // ConcertDayDateTime


// Returns month as a name for the input month number
function ConcertMonthIntToName(i_concert_month)
{
	ret_str = "";
	if ("1" == i_concert_month)
	{
		ret_str = ret_str + "Jan.";
	}
    else if ("2" == i_concert_month)
	{
		ret_str = ret_str + "Feb.";
	}
    else if ("3" == i_concert_month)
	{
		ret_str = ret_str + "März";
	}
    else if ("4" == i_concert_month)
	{
		ret_str = ret_str + "April";
	}	
    else if ("5" == i_concert_month)
	{
		ret_str = ret_str + "Mai";
	}	
    else if ("6" == i_concert_month)
	{
		ret_str = ret_str + "Juni";
	}	
    else if ("7" == i_concert_month)
	{
		ret_str = ret_str + "Juli";
	}	
    else if ("8" == i_concert_month)
	{
		ret_str = ret_str + "Aug.";
	}	
    else if ("9" == i_concert_month)
	{
		ret_str = ret_str + "Sep.";
	}	
    else if ("10" == i_concert_month)
	{
		ret_str = ret_str + "Okt.";
	}	
    else if ("11" == i_concert_month)
	{
		ret_str = ret_str + "Nov.";
	}	
    else if ("12" == i_concert_month)
	{
		ret_str = ret_str + "Dez.";
	}	
    else 
	{
		ret_str = ret_str + "Error";
	}	
	
	return ret_str;
	
} // ConcertMonthIntToName

// Returns a string for more information about the concert
function ConcertMorePriorDate(i_more_path, i_concert_year, i_concert_month, i_concert_day)
{
	ret_str = "";
	
	var ret_boolean = DateIsPassed(i_concert_year, i_concert_month, i_concert_day);
	if (ret_boolean == true)
		return ret_str;
	
	ret_str = ConcertMore(i_more_path);
	
	return ret_str;
	
} // ConcertMorePriorDate

// Returns a string for more information about the concert
function ConcertMore(i_more_path)
{
	ret_str = "";
	
	ret_str = ret_str + "<b>";
	
	ret_str = ret_str + "&nbsp;";
	
	ret_str = ret_str + "<A href=" + "'" + i_more_path + "'" + ">";
	
	ret_str = ret_str + "mehr";
	
	ret_str = ret_str + "</A>";
	
	ret_str = ret_str + "</b>";
	
	return ret_str;
	
} // ConcertMore


// Returns a straight line
function StraightLinePriorDate(i_concert_year, i_concert_month, i_concert_day)
{
	ret_str = "";
	
	ret_str = ret_str + "<b>";
	
	ret_str = ret_str + "_________________________________________________________________________________";
	
	ret_str = ret_str + "</b>";
	
	var ret_boolean = DateIsPassed(i_concert_year, i_concert_month, i_concert_day);
	if (ret_boolean == true)
		return ret_str;
	
	ret_str = StraightLine();	
	
	return ret_str;
	
} // ConcertMore




// Returns a straight line
function StraightLine()
{
	ret_str = "";
	
	ret_str = ret_str + "<b>";
	
	ret_str = ret_str + "_________________________________________________________________________________<br><br>";
	
	ret_str = ret_str + "</b>";
	
	
	return ret_str;
	
} // ConcertMore

// Returns a string for a list of musicians and their instruments if it is a coming concert
function ListMusiciansInstrumentsPriorDate(i_array_musicians, i_concert_year, i_concert_month, i_concert_day)
{
	ret_str = "";
	
	var ret_boolean = DateIsPassed(i_concert_year, i_concert_month, i_concert_day);
	if (ret_boolean == true)
		return ret_str;

	ret_str = ListMusiciansInstruments(i_array_musicians);
	
	return ret_str;
}  // ListMusiciansInstrumentsPriorDate

// Returns a string for a list of musicians and their instruments
function ListMusiciansInstruments(i_array_musicians)
{
	ret_str = "";
	for (index_musician=0;index_musician<i_array_musicians.length;index_musician++)
    {
		ret_str = ret_str + i_array_musicians[index_musician].Name + " " + 
		                    i_array_musicians[index_musician].Instrument + "<br>";
    }

	return ret_str;
}  // ListMusiciansInstruments

// Returns the name of the premises and the address as a string
function PremisesNameAddress(i_concert)
{
	return ret_str = i_concert.Place + ", " + i_concert.Street + ", " + i_concert.City;

}  // PremisesNameAddress

// Returns the date and the time for a concert as a string
function ConcertDateTime(i_concert)
{
	var month = i_concert.Month;
	if (month.length == 1)
		month = "0" + month;
	
    var day = i_concert.Day;
	if (day.length == 1)
		day = "0" + day;
	
	return ret_str = i_concert.DayName + " " + i_concert.Year + "-" + month  + "-" + day +
	                 " " + i_concert.TimeStartHour + ":" + i_concert.TimeStartMinute + " h";

}  // PremisesNameAddress


// Returns a string for a list of musicians and texts
function ListMusiciansTexts(i_array_musicians)
{
	ret_str = "";
	for (index_musician=0;index_musician<i_array_musicians.length;index_musician++)
    {
		var musician_text = i_array_musicians[index_musician].Text;
		
		if (musician_text.length > 10)
		{
		     ret_str = ret_str + 
		     "<b> <br>" + i_array_musicians[index_musician].Name + "<br> </b> " + 
		     musician_text + "<br>";
		}
    }

	return ret_str;
}  // ListMusiciansTexts


// Returns a string for a link to a sound sample
function LinkSoundSample(i_sound_sample_url)
{
	if (i_sound_sample_url.length < 5)
		return "";
	
   var ret_str = "<a href=" + "'" + i_sound_sample_url + "'" + 
                    " target=" + "'" + "_blank" + "'" + ">" + 
                    "<img src=" + "'" + "../images/IconVideo.jpg" 
		  + "'" + " alt=" + "'" + "Video" +"'" 
		  + " height=" + "'" + "30" + "'" + " >"
          + "</a>"
            			   
   return ret_str;
   
}  // LinkSoundSample

// Returns a string for a link to a sound sample
function LinkBandWebsite(i_band_website_url)
{
	if (i_band_website_url.length < 5)
		return "";
	
   var ret_str = "<a href=" + "'" + i_band_website_url + "'" + 
                    " target=" + "'" + "_blank" + "'" + ">" + 
                    "<img src=" + "'" + "../images/IconWWW.jpg" 
		  + "'" + " alt=" + "'" + "Band Website" +"'" 
		  + " height=" + "'" + "30" + "'" + " >"
          + "</a>"
            			   
   return ret_str;
   
}  // LinkBandWebsite

// Returns the link string for a small poster if it is a coming concert
function LinkSmallPosterPriorDate(i_path_photo, i_concert_number, i_next, i_concert_year, i_concert_month, i_concert_day)
{
	var ret_boolean = DateIsPassed(i_concert_year, i_concert_month, i_concert_day);
	if (ret_boolean == true)
		return "";
	
	var ret_str = LinkSmallPoster(i_path_photo, i_concert_number, i_next);
	
    return ret_str;	
			 
} // LinkSmallPoster

// Returns the link string for a small poster if it is a coming concert
function ShortTextPriorDate(i_short_text, i_concert_year, i_concert_month, i_concert_day)
{
	var ret_str = "";
	var ret_boolean = DateIsPassed(i_concert_year, i_concert_month, i_concert_day);
	if (ret_boolean == true)
		return ret_str;
	
	ret_str = i_short_text;
	
    return ret_str;	
			 
} // LinkSmallPoster


// Returns the link string for a small poster
function LinkSmallPoster(i_path_photo, i_concert_number, i_next)
{
		if (i_path_photo.length < 5)
		return "";
	
	var ret_str = "<A href=" + "'" + "Konzerte/KonzertPlakat_";
	
	if (i_next == true)
		ret_str = ret_str + "N_";
	
	if (i_concert_number.length == 1)
		ret_str = ret_str + "0";
	
	ret_str = ret_str + i_concert_number + ".htm" + "'" +">"   + 
	         ImgSmallPoster(i_path_photo) + "</A>";
	
    return ret_str;	
			 
} // LinkSmallPoster

// Returns the link string for a small poster
function LinkSmallPosterNoPath(i_path_photo, i_concert_number, i_next)
{
		if (i_path_photo.length < 5)
		return "";
	
	var ret_str = "<A href=" + "'" + "KonzertPlakat_";
	
	if (i_next == true)
		ret_str = ret_str + "N_";
	
	if (i_concert_number.length == 1)
		ret_str = ret_str + "0";
	
	ret_str = ret_str + i_concert_number + ".htm" + "'" +">"   + 
	         ImgSmallPoster(i_path_photo) + "</A>";
	
    return ret_str;	
			 
} // LinkSmallPosterNoPath

// Returns member data for the concert contact person defined by ContactConcertMemberNumber
// i_case Eq, 1: Name i_case Eq, 2: Telephone i_case Eq, 3: E-Mail
function ConcertContactPersonData(i_case)
{
	ret_str = "";
	for (index_member=0;index_member<members.length;index_member++)
    {
		var member_number = members[index_member].Nummer;
		
		if (member_number == ApplicationData.ContactConcertMemberNumber)
		{
			if (1 == i_case)
			{
				ret_str = members[index_member].Name + " " + members[index_member].FamilyName;
			}
			else if (2 == i_case)
			{
				ret_str = members[index_member].Telephone;
			}
			else if (3 == i_case)
			{
				ret_str = members[index_member].EmailAddress;
			}			
		}
    }

	return ret_str;	
}; // ConcertContactPersonData

// Returns concert contact person name
function ConcertContactPersonName()
{
	return ConcertContactPersonData(1);
} // ConcertContactPersonName

// Returns concert contact person telephone
function ConcertContactPersonTelephone()
{
	return ConcertContactPersonData(2);
} // ConcertContactPersonTelephone

// Returns concert contact person E-Mail
function ConcertContactPersonEmail()
{
	return ConcertContactPersonData(3);
} // ConcertContactPersonEmail

// Returns an array with active members
function GetActiveMembers()
{
	var active_members = new Array();
		
	for (index_member=0;index_member<members.length;index_member++)
    {
		var current_member = members[index_member];
		
		var in_vorstand = current_member.Vorstand;
		
		if (in_vorstand == "true")
		{
			active_members.push(current_member);
		}
	}
	
	return active_members;
} // GetActiveMembers


// Returns a (multi-line) string with data about the active members
function GetActiveMemberData()
{
	var ret_data = "";
	
	
	var active_members = GetActiveMembers();
	
	for (index_active_member=0;index_active_member<active_members.length;index_active_member++)
    {
		var path_photo = active_members[index_active_member].PhotoSmallSize;
		var member_img = "";
		if (path_photo.length > 5)
		{
			member_img = ImgSmall(path_photo);
		}
		else
		{
			member_img = "<br><br>"
		}	
		
		ret_data = ret_data + active_members[index_active_member].Name + " " +
		                      active_members[index_active_member].FamilyName + ", " +
							  active_members[index_active_member].PostCode + " " +
							  active_members[index_active_member].City + " (" +
							  active_members[index_active_member].TasksShort + ") " +
							  "<br><br>" + member_img + "<br><br><br>";
	}
	
	return ret_data;
	
} // GetActiveMemberData

// Returns a string for a small image
function ImgSmall(i_path_photo)
{
  return  "<img src=" + "'" + i_path_photo 
		  + "'" + " alt=" + "'" + "Bild" +"'" 
		  + " width=" + "'" + "80" + "'" + " >"	 ;
}  // ImgSmall








