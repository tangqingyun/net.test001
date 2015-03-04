<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="etao.aspx.cs" Inherits="AirTicket.etao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>一淘网-登陆</title>
    <script src="jquery-1.4.2.min.js"></script>
    <script>
        $(function () {
            //$("#J_StaticForm").submit();
        });


    </script>
</head>
   
<body>
 
 
<div id="page2">
<div id="content">
	<div id="J_LoginBox"  class="login-box   no-dynamic  " >
	
<div class="bd">    	 
   <div id="J_Static" class="static">
 
    <form id="J_StaticForm" action="https://login.taobao.com/member/login.jhtml" method="post" target="_parent">
       <input type="hidden" name="TPL_username" id="TPL_username_1" class="login-text J_UserName" value="15901473139" maxlength="32" tabindex="1"/>       
            	<input type="hidden" aria-labelledby="password-label" value="*tamny2tamny*" name="TPL_password" id="TPL_password_1" class="login-text" maxlength="20" tabindex="2" />     
        <div class="submit">
                                                    
            <input type="hidden" name="loginsite" value="0" id="J_loginsite"/>
            <input type="hidden" name="newlogin" value="" />
           
            <input type="hidden" id="J_TPL_redirect_url" name="TPL_redirect_url" value="http://login.etao.com/loginmid.html?redirect_url=http%3A%2F%2Fdianying.taobao.com%2F&" />                                          
            <input type="hidden" id="J_From" name="from" value="etao" />
 
 
            <input type="hidden" name="fc" value="default" />
 
            <input type="hidden" id="J_CssStyle" name="style" value="miniall" />
            
            <input type="hidden"  name="css_style" value="etao" />
            
            <input type="hidden" name="tid" />
 
            <input type="hidden" name="support" value="000001"/>
 
            <input type="hidden" name="CtrlVersion" value="1,0,0,7"/> 
			
            <input type="hidden" name="loginType" value="3" />
 
            <input type="hidden" name="minititle" value="etao"/>
 
            <input type="hidden" name="minipara" value=""/>
			            
			<input type="hidden" id="um_to" name="umto" value="T5748f211cce20f0f547e9e4d881bea54"/>
            
            <input type="hidden" name="pstrong" value="" />
 
            <input type="hidden" name="llnick" id="llnick1" value="" />                                                
            
            <input type="hidden" id="J_sign" name="sign" value=""/>
            <input type="hidden" id="J_need_sign" name="need_sign" value=""/>
                        
            <input type="hidden" id="J_isIgnore" name="isIgnore" value=""/>
			 <input type="hidden" id="J_full_redirect" name="full_redirect" value="true"/>
            <input type="hidden" name="popid" value=""/>
            <input type="hidden" name="callback" value=""/>
            <input type="hidden" id="J_guf" name="guf" value=""/>
            <input type="hidden" id="J_not_duplite_str" name="not_duplite_str" value=""/>                
            <input type="hidden" name="need_user_id" value=""/>   
            <input type="hidden" name="poy"/> 
            <input type="hidden" id="gvfdc" name="gvfdcname" value=""/>
        <%--    <input type="hidden" name="gvfdcre" value="687474703A2F2F6C6F67696E2E6574616F2E636F6D2F3F73706D3D313030322E312E312E322E5648467049432672656469726563745F75726C3D687474702533412532462532467777772E6574616F2E636F6D2532462533467462706D25334474"/>--%>
             
            <input type="hidden" id="J_from_encoding" name="from_encoding" value=""/> 
            
            <input type="hidden" id="J_sub" name="sub" value=""/> 
            <input type="hidden" name="oslanguage"/>
            <input type="hidden" name="sr"/>
            <input type="hidden" name="osVer"/>
            <input type="hidden" name="naviVer"/>
           <button type="submit" class="J_Submit" tabindex="5" id="J_SubmitStatic">登　录</button>
        </div>
        
        
    </form>
</div>
				





		</div>
	</div>
</div>
</div>
 
 
 
 


 
 

 
</body>

