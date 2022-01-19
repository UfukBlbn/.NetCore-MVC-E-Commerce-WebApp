$(document).ready(function() {
  
 
  
    var table = $('#example').DataTable({ 
          select: false,
          "columnDefs": [{
              className: "Name", 
              "targets":[0],
              "visible": false,
              "searchable":false
          }]
      });//End of create main table
  
    
    $('#example tbody').on( 'click', 'tr', function () {
     
      alert(table.row( this ).data()[0]);
  
  } );
  });