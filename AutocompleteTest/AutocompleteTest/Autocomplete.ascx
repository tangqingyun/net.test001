<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Autocomplete.ascx.cs" Inherits="AutocompleteTest.Autocomplete" %>


<input type="text" id="autocomplete" size="50" name="autocomplete" />
<input type="hidden" id="autokey" name="autokey" value="" />
<input type="hidden" id="hdDataType" runat="server" clientidmode="Static"/>

<link rel="stylesheet" type="text/css" href="css/jquery.autocomplete.css" />
<script type="text/javascript" src="jscript/jquery.js"></script>
<script type='text/javascript' src='jscript/jquery.autocomplete.js'></script>

<script type="text/javascript">
   
    $(function () {
        $("#autocomplete").autocomplete('Autocomplete.ashx?action=<%=DataType %>', {
        multiple: false,
        dataType: "json",
        parse: function (data) {
            return $.map(data, function (row) {
                return {
                    data: row,
                    value: row.name,
                    //result: row.name + " <" + row.to + ">"
                    result: row.name
                }
            });
        },
        formatItem: function (item) {          
            return item.name;
        }
    }).result(function (e, item) {
        $("#autokey").val(item.key);       
        });

    });
  

</script>
