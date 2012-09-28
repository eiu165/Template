Person = (data) ->
    name = ko.observable(data.name)
    name:name
    
Vehicle = (data) ->
    make = ko.observable(data.make)
    make:make 

PersonListViewModel =-> 
    people = ko.observableArray([])  
    vehicle = ko.observableArray([])                
    addPerson = ->  
        people.push({ name: "New at " + new Date() })  
    removePerson = ->   
        people.remove(this) 
    load = -> 
        console.log 'load' 
        #$.getJSON("/Users/Get",(allData)->mapData(allData))
        allData = '{"people" : [{"name":"a"},{"name":"b"},{"name":"c"}],  "vehicle" : [{"make":"x"},{"make":"z"}]}'   
        map allData 
    map = (data) ->
        mappedItems = $.map($.parseJSON(data).people, (item)-> Person(item) )
        people(mappedItems)  
        mappedV= $.map($.parseJSON(data).vehicle, (item)-> Vehicle(item) )
        vehicle (mappedV)  
    save =->
        console.log 'save' 
    people:people    
    vehicle :vehicle 
    load:load   
    save:save
    addPerson :addPerson  
    removePerson :removePerson             
	
$(->    
    a = new PersonListViewModel() 
    a.load()
    ko.applyBindings(a) 
    #debugger
    @
	)