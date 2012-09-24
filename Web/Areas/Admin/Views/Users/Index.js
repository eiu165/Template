



$(function () {
    function User(data) {
        this.userName = ko.observable(data.userName);
    }

    function UserList () {
        // Data
        var self = this; 
        self.users = ko.observableArray([]);  
        self.MapData = function (allData) {
            var mappedItems = $.map(allData, function (item) { return new User(item); });
            self.users(mappedItems);
            self.configureUserAutocomplete();
        };  
        self.cancel = function () {
            self.load();
        };
        self.load = function () { 
            // Load initial state from server, convert it to Tag instances, then populate self.tags 
            $.getJSON("/Admin/Users/GetUsers", function (allData) { 
                self.MapData(allData);
            });
        }; 
        self.load();
    }

    ko.applyBindings(new UserList(), $('#UserList')[0]);

});


