# R U Being Served?

## Problem 
Every few years billboards appear saying “Vote for Me” and representatives for councils and health boards are voted into office, but do they represent us?

How do we know what they are discussing, or even if they attend meetings?

Are they discussing the important emerging topics
- The climate emergency  
- Mental health  
- Water quality and supply  
- Energy availability  

What are they doing to address these?

We could go to a meeting, watch it streamed online, read the minutes, or rely on the news to tell us, but is there a way that technology can help?

## Solution Overview

Meeting schedules and minutes for 2019 were scraped to produce tables of meetings and councillor attendances. The meeting text was also analysed to produce word counts for a set of meetings.

The attendance information was visualised for each organisation, and the word counts turned into word clouds and used for trend analysis of words found in the minutes over time.

Mapping layers from stats have been used to provide the initial landing page and navigation, and councillor photos are used in the attendance visualisation.

## Finished Prototype

Landing Page - select the authority area
![Landing Page](https://github.com/AdrianTVB/arewebeingserved/blob/master/Website%20Snapshots/Landing%20Page(map).PNG)

Attendance visualisation - how many meetings were attended by each councillor
![Attendance Visualisation](https://github.com/AdrianTVB/arewebeingserved/blob/master/Website%20Snapshots/Official%20Attendance.PNG)

Word Cloud - what has been discussed in 2019
![Word Cloud](https://github.com/AdrianTVB/arewebeingserved/blob/master/Website%20Snapshots/napierwordcloud.png)

Interactivie Dashboards
![Interactive Dashboards]()

## Extensions - Not Implemented

Word Count Dashboard - what are the hot topics
![Word Cloud Dashboard](https://github.com/AdrianTVB/arewebeingserved/blob/master/Team%20Planning/HotTopics.png)  
![Word Cloud Dashboard](https://github.com/AdrianTVB/arewebeingserved/blob/master/Team%20Planning/Dashboard.png)  
![Word Cloud Dashboard](https://github.com/AdrianTVB/arewebeingserved/blob/master/Team%20Planning/TimeTrends.png)  

## Technology Used

The overview of the architecture / data flow is shown in the diagram below.

![Architecture Diagram](https://raw.githubusercontent.com/AdrianTVB/arewebeingserved/master/Team%20Planning/Architecture%20Diagram.png)

Initially Python scraping of the meetings and minutes was investigated, but we reverted to manual scraping and cleaning of the data due to the lack of standardisation of the raw forms, and lack of time.  Csv files were used as an interim step, powerBI was used as a prototyping tool to check the concept.  The full stack was developed in parallel, using an Azure stack consisting of C# ETL from csv into an Azure SQL database which feeds the user interface via a C# Webapp. 

For the concept static Word Clouds were generated using a free online tool and linked to the Webapp.
A PowerBI dashboard has also been linked, and further functionality has been shown using screenshots of a prototype powerBI dashboard. 

## Data Sources

| Name | Description | Url |
| ------------- | ------------- | ------------- |
| NCC Meeting Minutes | Minutes of all Napier City Council meetings. Of particular interest to us is the attendees list of the councillors. | http://napier.infocouncil.biz/ |
| HDC Meeting Minutes | Minutes of all Hastings City Council meetings. Of particular interest to us is the attendees list of the councillors. | http://hastings.infocouncil.biz/ |
| TODO: HBRC Meeting Minutes | Minutes of all Hawkes Bay Regional Council meetings. Of particular interest to us is the attendees list of the councillors. | http://hawkesbay.infocouncil.biz/ |
| TODO: DHB Minutes | Minutes of all District Health Board meetings. Of particular interest to us is the attendees list of the councillors. | |
| Stats NZ Local Authority Boundary Data | The bounding box of area that each local council serves.  | https://datafinder.stats.govt.nz/layer/98755-territorial-authority-2019-generalised/ |
| Stats NZ Regional Council Boundary Data | The bounding box of area that the regional council serves. | https://datafinder.stats.govt.nz/layer/98763-regional-council-2019-generalised/ | 
| Health Board Boundary Data | Not used in this version | |


## Award Categories Entered

### National

 - Innovate New Zealand
 - Combating the Climate Emergency
 - Best Creative Use Of Technology
 - Most Artistic use of data (outside the box)
 - Best Way to Promote Positive Mental Health
 
 ### International

 - Reducing CBD Traffic Congestion
 - Optimise energy and water resource planning
 
## The Transparency Ninja's 
  Team Lead: Jeff Cooke
  
  Team Members: 
  
   - Himalaya Patel
   - Sean Heemeyer
   - Adrian Teding van Berkhout
   - Gabe Ward
   - Kamaljit Singh
   

