(function() {
  var Movie, MovieListViewModel;

  Movie = function(data) {
    var name;
    name = ko.observable(data.name);
    return {
      name: name
    };
  };

  MovieListViewModel = function() {
    var addMovie, load, map, movies, removeMovie, save;
    movies = ko.observableArray([]);
    addMovie = function() {
      return movies.push({
        name: "New at " + new Date()
      });
    };
    removeMovie = function() {
      return movies.remove(this);
    };
    load = function() {
      console.log('load');
      return $.getJSON("Movies/GetMovies", function(allData) {
        return map(allData);
      });
    };
    map = function(data) {
      var mappedItems;
      mappedItems = $.map(data.movies, function(item) {
        return Movie(item);
      });
      return movies(mappedItems);
    };
    save = function() {
      console.log('save');
      return $.post("Movies/SaveMovies", {
        "movies": [
          {
            "name": "a"
          }, {
            "name": "b"
          }, {
            "name": "c"
          }
        ]
      }, function() {
        return alert('aaa');
      });
    };
    return {
      movies: movies,
      load: load,
      save: save,
      addMovie: addMovie,
      removeMovie: removeMovie
    };
  };

  $(function() {
    var a;
    a = new MovieListViewModel();
    a.load();
    ko.applyBindings(a);
    return this;
  });

}).call(this);
