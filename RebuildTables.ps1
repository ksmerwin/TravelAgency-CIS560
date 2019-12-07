Param(
   [string] $Server = "(localdb)\TravelAgency",
   [string] $Database = "TravelAgency"
)

# This script requires the SQL Server module for PowerShell.
# The below commands may be required.

# To check whether the module is installed.
# Get-Module -ListAvailable -Name Sqlps;

# Install the SQL Server Module
# Install-module -Name SqlServer -Scope CurrentUser

# Import the SQL Server Module.    
# Import-Module Sqlps -DisableNameChecking;

Write-Host ""
Write-Host "Rebuilding database Tables $Database on $Server..."

Write-Host "Dropping tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\DropTables.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\Location.Cities.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\HotelsTables\Hotel.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AirlinesTables\Flight.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AttractionsTables\Attraction.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\RestaurantsTables\Restaurant.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\Cars\CarRental.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AgencyTables\ContactInfo.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AgencyTables\Customer.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AgencyTables\Agents.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AgencyTables\Trips.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AgencyTables\Reservations.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AirlinesTables\BoardingPass.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\AttractionsTables\AttractionTicket.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\Cars\CarRentalReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\HotelsTables\HotelReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Tables\RestaurantsTables\RestaurantReservation.sql"

Write-Host "Inserting data..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\AgentsData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\CitiesData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\CustomerData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\TripsData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\HotelsData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\FlightsData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\AttractionsData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\RestaurantsData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\CarRentalAgencysData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Data\ReservationsData.sql"

Write-Host "Creating Agency Create procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateAgent.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateAttractionTicket.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateBoardingPass.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateContactInfo.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateCustomer.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateRestaurantReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.CreateTrip.sql"

Write-Host "Creating Agency Get procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.GetAgent.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.GetAgents.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.GetCustomer.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.GetCustomers.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.GetTrip.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.GetTrips.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.GetReservations.sql"

Write-Host "Creating Agency Retrieve procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.RetrieveAgentTrips.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.RetrieveCustomerContactInfo.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.RetrieveCustomerTrips.sql"

Write-Host "Creating Agency Save procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.SaveCustomerContactInfo.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AgencyProcedures\Agency.SaveTrip.sql"

Write-Host "Creating Airlines procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AirlinesProcedures\Airlines.CreateBoardingPass.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AirlinesProcedures\Airlines.CreateFlight.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AirlinesProcedures\Airlines.GetFlight.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AirlinesProcedures\Airlines.GetBoardingPass.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AirlinesProcedures\Airlines.RetrieveFlightInfo.sql"

Write-Host "Creating Attractions procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AttractionsProcedures\Attractions.CreateAttraction.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AttractionsProcedures\Attractions.CreateAttractionTicket.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AttractionsProcedures\Attractions.GetAttraction.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\AttractionsProcedures\Attractions.GetAttractionTicket.sql"

Write-Host "Creating Cars procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\CarsProcedures\Cars.CreateCarRental.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\CarsProcedures\Cars.CreateCarRentalReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\CarsProcedures\Cars.GetAgencyName.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\CarsProcedures\Cars.GetAgencyByName.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\CarsProcedures\Cars.GetAgencyByID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\CarsProcedures\Cars.GetCarReservationInfo.sql"

Write-Host "Creating Hotels procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\HotelsProcedures\Hotels.CreateHotel.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\HotelsProcedures\Hotels.CreateHotelReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\HotelsProcedures\Hotels.GetHotel.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\HotelsProcedures\Hotels.GetHotelReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\HotelsProcedures\Hotels.FetchHotel.sql"

Write-Host "Creating Location procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\LocationProcedures\Location.CreateCity.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\LocationProcedures\Location.GetCities.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\LocationProcedures\Location.GetCitiesByName.sql"

Write-Host "Creating Restaurant procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\RestaurantsProcedures\Restaurants.CreateRestaurant.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\RestaurantsProcedures\Restaurants.CreateRestaurantReservation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\RestaurantsProcedures\Restaurants.GetRestaurant.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\RestaurantsProcedures\Restaurants.GetRestaurantByName.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Procedures\RestaurantsProcedures\Restaurants.GetRestaurantReservation.sql"

Write-Host "Creating Report procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DataModeling\Sql\Reports\Agency.CheapestOptions.sql"


Write-Host "Rebuild completed."
Write-Host ""
