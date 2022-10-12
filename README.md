# CAB201_Assessment_2_Emmey

## User Story 1
- On start:
	- Main Menu Dialogue displayed
		- 3 options
			- (1) Register
			- (2) Sign In
			- (3) Exit
- User input required
	- valid range between 1-3
	- error if outside range (eg: WARNING: Option outside of range)
- All actions will use numeric menus
	- exit will be a seperate command
- when exit is used, program terminates gracefully
- Other selections are dealt with as follows

## User Story 2
- When 1 is pressed
	- user enter name
		- name is not null
	- user enter email
		- use regex to check valid email
	- user enter password
		- use regex to check valid password
	- add all entered information to registeredUsers.csv
		- add ",false," to the end for first time sign in check

## User Story 3
- when 2 is pressed
	- user enter email
		- check if email is an email
		- check if the email exists in registeredUsers.csv
	- user enter password
		- check if password exists with email
	- if credentials match
		- client menu is displayed
	- else 
		- display error
		- display main menu

## User Story 4
- log out available in client menu
- when 6 is pressed
	- main menu is displayed
	- all credentials forgotten

## User Story 5
- first time user logs in
	- personal details dialogue displayed
	- user enters home address
		- unit number
		- street number
		- street name
		- street suffix
		- city
		- state
		- postcode
	- home address is validated
	- Client menu is displayed

## User Story 6
- All client data is saved to a text file (registeredUsers.csv) immediately

## User Story 7
- all user data is available when system starts

## User Story 8
- when 1 is pressed in client menu
	- display product advertisement dialogue
		- user enters product name
			- check if not null
		- user enters product description
			- check if not null
			- check if not the same as name
		- user enters price
			- check if it has a $
			- check if it's a double formatted as 0.00
	- all information is added to products.csv

## User Story 9


## User Story 10


## User Story 11


## User Story 12


## User Story 13


## User Story 14


## User Story 15
