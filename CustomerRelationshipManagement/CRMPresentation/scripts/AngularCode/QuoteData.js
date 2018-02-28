var app = angular.module("myapp", []);

app.controller("ListController", ['$scope', '$http', function ($scope, $http) {

    $("#custDetails").hide();

    //Load Data to Customer DropdownList
    $scope.GetData = function () {
        $http({
            method: 'GET',
            url: '/Customer/GetCustomerList'
        }).
          then(function (response) {
              $scope.customeDetails = response.data;
          }, function () {
              alert("Error Occur");
          })
    };

    //Get Customer Details on Dropdown Change
    $scope.GetCustomerDetails = function () {
        $("#custDetails").hide();

        if ($scope.cust) {
            $("#custDetails").show();

            $http({
                method: 'POST',
                url: '/Customer/GetCustDetails/',
                data: JSON.stringify({ CustomerID: $scope.cust })
            }).
                   then(function (response) {
                       $scope.PrimaryMail = response.data.PrimaryMailID;
                       $scope.PrimayPhone = response.data.PrimaryPhoneNo;
                       $scope.PersonName = response.data.ContactPersonName;
                       $scope.PersonNo = response.data.ContactPersonNo;

                       $scope.BillingAddress = response.data.BillingAddress;
                       $scope.BillingAddress1 = response.data.BillingAddress1;
                       $scope.BillingCity = response.data.BillingCity;
                       $scope.BillingState = response.data.BillingState;
                       $scope.BillingCountry = response.data.BillingCountry;
                       $scope.BillingPincode = response.data.BillingPincode;

                       $scope.ShippingAddress = response.data.ShippingAddress;
                       $scope.ShippingAddress1 = response.data.ShippingAddress1;
                       $scope.ShippingCity = response.data.ShippingCity;
                       $scope.ShippingState = response.data.ShippingState;
                       $scope.ShippingCountry = response.data.ShippingCountry;
                       $scope.ShippingPincode = response.data.ShippingPincode;

                   });
        }
    };
  

    //Add Empty Line Item
    $scope.quoteDetails = [];
    $scope.addNew = function (quoteDetail) {
        $scope.quoteDetails.push({
            'desc': "",
            'price': "",
            'qty': "",
            'totAmount': "",
        });
    };

    //Remove Line Item
    $scope.remove = function () {
        var newDataList = [];
        $scope.selectedAll = false;
        angular.forEach($scope.quoteDetails, function (selected) {
            if (!selected.selected) {
                newDataList.push(selected);
            }
        });
        $scope.quoteDetails = newDataList;
    };

   //Select All Checkbox Click
    $scope.checkAll = function () {
        if (!$scope.selectedAll) {
            $scope.selectedAll = true;
        } else {
            $scope.selectedAll = false;
        }
        angular.forEach($scope.quoteDetails, function (quoteDetail) {
            quoteDetail.selected = $scope.selectedAll;
        });
    };

    //Calculate Line Item Total 
    $scope.calItemTot = function (index) {
        var price = $scope.quoteDetails[index].price;
        var qty = $scope.quoteDetails[index].qty;
        var tamount = parseInt(price) * parseInt(qty);
        $scope.quoteDetails[index].totAmount = tamount;
        $scope.calTotal();
    };

//Calculate Total Amount from Item Amount
    var totalAmnt=0;
    $scope.calTotal = function () {
        angular.forEach($scope.quoteDetails, function (quoteDetail) {
            totalAmnt = parseInt(totalAmnt) + parseInt(quoteDetail.totAmount);
        });
        $scope.total = totalAmnt;
    };


//Create New Quote
    $scope.create = function () {
        $scope.QuoteDetails = {};
        $scope.QuoteDetails.CustomerID = $scope.cust;
        $scope.QuoteDetails.PrimaryMailID = $scope.PrimaryMail;
        $scope.QuoteDetails.PrimaryPhoneNo = $scope.PrimayPhone;
        $scope.QuoteDetails.ContactPersonName = $scope.PersonName;
        $scope.QuoteDetails.ContactPersonNo = $scope.PersonNo;
        $scope.QuoteDetails.BillingAddress = $scope.BillingAddress;
        $scope.QuoteDetails.BillingAddress1 = $scope.BillingAddress1;
        $scope.QuoteDetails.BillingCity = $scope.BillingCity;
        $scope.QuoteDetails.BillingState = $scope.BillingState;
        $scope.QuoteDetails.BillingCountry = $scope.BillingCountry;
        $scope.QuoteDetails.BillingPincode = $scope.BillingPincode;
        $scope.QuoteDetails.ShippingAddress = $scope.ShippingAddress;
        $scope.QuoteDetails.ShippingAddress1 = $scope.ShippingAddress1;
        $scope.QuoteDetails.ShippingCity = $scope.ShippingCity;
        $scope.QuoteDetails.ShippingState = $scope.ShippingState;
        $scope.QuoteDetails.ShippingCountry = $scope.ShippingCountry;
        $scope.QuoteDetails.ShippingPincode = $scope.ShippingPincode;
        $scope.QuoteDetails.TotalAmount = $scope.total;

        $scope.QuoteItems = [];
        $scope.items= {};
        angular.forEach($scope.quoteDetails, function (quoteDetail) {
            $scope.items.Description = quoteDetail.desc;
            $scope.items.Price = quoteDetail.price;
            $scope.items.Qty = quoteDetail.qty;
            $scope.items.ItemTotal = quoteDetail.totAmount;
            debugger;
            $scope.QuoteItems.push($scope.items);
        });
        $scope.QuoteDetails.QuoteItemsList = $scope.QuoteItems;
       
        $http({
            method: "post",
            url: "http://localhost:50480/Quote/SaveQuote",
            datatype: "json",
            data: JSON.stringify($scope.QuoteDetails)
        }).then(function (response) {
            alert(response.data);
            
        })
    };

}]);