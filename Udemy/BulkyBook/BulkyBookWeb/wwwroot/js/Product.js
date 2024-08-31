var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
  
    dataTable = $('#tbl_data').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "Width": "15%" },
            { "data": "isbn", "Width": "15%" },
            { "data": "price", "Width": "15%" },
            { "data": "category.name", "Width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role = "group" >
                               <a href="/Admin/Product/Upsert?id=${data}" class="btn">Edit</a>
                               &nbsp;&nbsp;&nbsp;
                               <a onClick=Delete('/Admin/Product/Delete/'+${data}) class="btn">Delete</a>
                            </div>`
                    
                }, "Width": "15%"
                   
            }
        ]
    });
}



function Delete(url)
{
   $.ajax({
        url: url,
        type: 'DELETE',
        success: function (data) {
            if (data.success) {
                dataTable.ajax.reload();
                alert(data.message);
            }
            else {
                alert(data.message);
            }
        }
    })
}







