Movie = (data) ->
    name = ko.observable(data.name)
    name:name
     
MovieListViewModel =-> 
    movies = ko.observableArray([])                
    addMovie = ->  
        movies.push({ name: "New at " + new Date() })  
    removeMovie = ->   
        movies.remove(this)
    load = -> 
        console.log 'load' 
        $.getJSON("Movies/GetMovies",(allData) -> map allData )  
    map = (data) ->   
        mappedItems = $.map( data.movies, (item)-> Movie(item) ) 
        movies(mappedItems)   
    save =->
        console.log 'save'  
        $.post("Movies/SaveMovies", {"movies" : [{"name":"a"},{"name":"b"},{"name":"c"}]} , -> alert 'aaa')
    movies:movies     
    load:load   
    save:save
    addMovie :addMovie  
    removeMovie :removeMovie             
	
$(->    
    a = new MovieListViewModel() 
    a.load()
    ko.applyBindings(a) 
    #debugger
    @
	)