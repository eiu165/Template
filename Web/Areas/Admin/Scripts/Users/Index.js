(function() {
  var Person, PersonListViewModel, Vehicle;

  Person = function(data) {
    var name;
    name = ko.observable(data.name);
    return {
      name: name
    };
  };

  Vehicle = function(data) {
    var make;
    make = ko.observable(data.make);
    return {
      make: make
    };
  };

  PersonListViewModel = function() {
    var addPerson, load, map, people, removePerson, save, vehicle;
    people = ko.observableArray([]);
    vehicle = ko.observableArray([]);
    addPerson = function() {
      return people.push({
        name: "New at " + new Date()
      });
    };
    removePerson = function() {
      return people.remove(this);
    };
    load = function() {
      console.log('load');
      return $.getJSON("/Users/GetUsers", function(allData) {
        return map(allData);
      });
    };
    map = function(data) {
      debugger;
      var mappedItems;
      mappedItems = $.map(data.people, function(item) {
        return Person(item);
      });
      debugger;
      return people(mappedItems);
    };
    save = function() {
      return console.log('save');
    };
    return {
      people: people,
      vehicle: vehicle,
      load: load,
      save: save,
      addPerson: addPerson,
      removePerson: removePerson
    };
  };

  $(function() {
    var a;
    a = new PersonListViewModel();
    a.load();
    ko.applyBindings(a);
    return this;
  });

}).call(this);
