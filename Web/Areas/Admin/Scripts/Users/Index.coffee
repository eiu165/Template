
User =->
    UserName = ko.observable(data.UserName)       
	UserName:UserName 
	
UserList =->
	users = ko.observableArray([]) 
	MapData = (allData)  -> 
		mappedItems = $.map(allData, (item)-> User(item) ) 
		users(mappedItems) 
	load =->  $.getJSON("/Admin/Users/GetUsers",   (allData) ->   MapData(allData)  ) 
	cancel =-> load   
	users:users

	 
		