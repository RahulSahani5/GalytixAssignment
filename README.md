# GalytixAssignment

Input of the CountryGwp Controller:

country - A string containing the name of the country.

lob - A string containing the names of the lineOfBusiness seperated by ",".

for testing I used curl with commmand for windows as:
"curl -X POST -F "country=ae" -F"lob=transport,liability" localhost:9091/api/gwp/avg/CountryGwp"

**Note**- The output returned if avg of the years between 2008-2015 for which data is present.
