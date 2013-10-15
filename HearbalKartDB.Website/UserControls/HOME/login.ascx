<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login.ascx.cs" Inherits="UserControls_HOME_login" %>
    <div class="signupopupbox" style="display: block;">
        <div class="signupopinner">
            <a onclick=" return CloseLogin();" class="closepopup" tabindex="12" id="close-pop" href="javascript: void(0)">
                <img alt="" src="http://i2.sdlcdn.com/img/signup/close_signup.png"></a>
        </div>
        <div style="position: relative;">
            <ul class="headtabs">
                <li style="margin-left:0px"><a class="active" href="javascript: void(0)" id="log" onclick="return tabclick(true);" tabindex="7">Login</a></li>
                <li><a href="javascript: void(0)" id="sig" onclick="return tabclick(false);" tabindex="8" class="">Sign Up</a></li>
                <div class="clear"></div>
            </ul>
        </div>
        <div style="margin-top: 32px;" class="signininner">
            <div class="sign-in-using">Sign in using</div>
            <span onclick="return window.widget.fbLogin('https://www.facebook.com/dialog/oauth?client_id=275135645938863&amp;redirect_uri=http://www.snapdeal.com/j_spring_facebook_security_check&amp;scope=email,user_location,user_birthday');" class="social-web-left"><a href="javascript: void(0)">
                <img alt="" src="http://i4.sdlcdn.com/img/signup/facebookButt.jpg"></a></span><span onclick="return window.widget.rpxLogin('https://snapdeal.rpxnow.com/openid/start?openid_identifier=https%3A%2F%2Fwww.google.com%2Faccounts%2Fo8%2Fid&amp;token_url=http://www.snapdeal.com/login_security_check?source=google');" class="social-web"><a href="javascript: void(0)"><img alt="" src="http://i3.sdlcdn.com/img/signup/googleButt.jpg"></a></span><span onclick="return window.widget.rpxLogin('https://snapdeal.rpxnow.com/openid/start?openid_identifier=http%3A%2F%2Fme.yahoo.com%2F&amp;force_reauth=true&amp;display=popup&amp;token_url=http://www.snapdeal.com/login_security_check?source=yahoo');" class="social-web"><a href="javascript: void(0)"><img alt="" src="http://i2.sdlcdn.com/img/signup/yahooButt.jpg"></a></span><div>
                    <br />
                    <br />
                    <br />
                    <p class="text_11">
                        <img align="absbottom" alt="" src="images/lock.png">
                        &nbsp; Be assured, we do not store your password
                    </p>
                </div>
            <div class="seperation">
                <img alt="" src="images/img_or.png">
            </div>
        </div>
        <div id="tab1" class="signininner2">
            <div class="error" id="ajaxSigninResponse"></div>
            <div style="display: none" class="error" id="prevSource">You have signed up through <strong><span id="pSource"></span></strong>. Please click the same icon to login again. </div>
            <form action="" id="ajaxSignin" method="post">
                <span class="signinheads">Your Email Id</span><input type="text" onmouseout="return window.widget.checkPrevSource();" class="login-text login-input-white" onclick="changeColor()" tabindex="1" title="username" size="20" value="eg. xyz@gmail.com" name="j_username" id="j_username" style="color: rgb(25, 25, 25);"><span style="margin-top: 5px" class="signinheads">Password</span><input type="password" class="login-text login-input" tabindex="2" title="password" value="" name="j_password" id="j_password"><div class="error" id="invalidPassword"></div>
                <span style="margin-top: 5px;" class="forgottext"><a onclick="forgotPassword()" class="forgottxt" href="javascript: void(0)" tabindex="3">Forgot your password ?</a></span><div class="popup-form-row">
                    <input type="checkbox" style="float: left; margin-left: -10px;" tabindex="4" value="1" name="_spring_security_remember_me" id="remember" checked="true"><input type="hidden" value="true" name="ajax"><label style="padding-top: 3px; margin: 0px;" class="rememberme" for="remember">Remember me on this computer.</label>
                </div>
                <div class="signinbottom overhid login-signinbottom">
                    <span class="signupbtn lfloat"><a href="javascript: void(0)">
                        <input type="submit" onclick="return window.widget.loginFormValidate();" tabindex="5" value="" id="signin_submit"></a></span> <span style="padding-top: 6px; margin-left: 6px;" class="crtacc lfloat"><strong class="login-or">or</strong> &nbsp; <a onclick="createAccount()" tabindex="6" class="createacc" href="javascript: void(0)">Create your Account Now &gt;&gt;</a></span>
                </div>
            </form>
        </div>
        <div id="tab2" style="display:none;">
            <div class="popup-form">
                <div class="error sign-resp-err" id="ajaxSignupResponse"></div>
                <form style="margin-left: 6px;" action="" id="ajaxSignup" method="post">
                    <div class="popup-form-row">
                        <div class="leftside"><span style="margin-top: 8px;" class="signinheads">Your Email Id</span></div>
                        <input type="text" class="login-text white-text signup-email-input" onclick="changeColor()" tabindex="1" title="username" value="eg. xyz@gmail.com" name="j_username" id="Text1" style="color: rgb(25, 25, 25);"></div>
                    <div class="popup-form-row">
                        <div class="leftside"><span style="margin-top: 5px;" class="signinheads">Password</span></div>
                        <input type="password" class="login-text sign-input-pass" tabindex="2&quot;" title="password" value="" name="j_password" id="Password1"></div>
                    <div class="popup-form-row">
                        <div class="leftside"><span class="signinheads">Confirm Password</span></div>
                        <input type="password" class="login-text sign-input-pass" tabindex="3" title="password" value="" name="j_confpassword" id="j_confpassword"></div>
                    <div class="popup-form-row">
                        <input type="hidden" value="true" name="ajax"><input type="hidden" value="3ede6db9abf2b9f4df7c91eb107f712e8dbbd365" name="CSRFToken" id="CSRFToken"><input type="checkbox" name="agree" id="agree" tabindex="4" class="checkbox" checked="true"><label style="font-size: 11px;" class="remember" for="agree">I have read and I agree to the <a target="_blank" href="http://www.snapdeal.com/info/terms">Terms of use.</a></label><br>
                        <label style="display: none;" class="error" generated="true" for="agree">Please accept our policy</label></div>
                    <div style="margin-bottom: 30px; margin-top: 8px;" class="popup-form-row overhid"><span class="signupbtn  lfloat"><a href="javascript: void(0)">
                        <input type="submit" onclick="    return window.widget.signupFormValidate();" tabindex="5" value="" style="background: url(images/signup_btn.png) no-repeat;" id="signup_submit"></a></span> <span style="padding-top: 6px; margin-left: 6px;" class="crtacc lfloat"><strong class="login-or">or</strong> &nbsp; Already Registerd <a onclick="alreadyAccount()" tabindex="6" class="loginacc" href="javascript: void(0)">Login to your Account &gt;&gt;</a></span></div>
                </form>
            </div>
        </div>
    </div>
<script language="javascript" type="text/javascript">
    function CloseLogin() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('signin_box').style.display = 'none';
        return isValid;
    }
    function tabclick(status) {
        var isValid = false;
        if (status ==true) {
            document.getElementById('tab2').style.display = 'none';
            document.getElementById('tab1').style.display = 'block';
            $("#log").addClass("active");
            $("#sig").removeClass("active");
        }
        else {
            
            document.getElementById('tab2').style.display = 'block';
            document.getElementById('tab1').style.display = 'none';
            $("#log").removeClass("active");
            $("#sig").addClass("active");

        }
        return isValid;
    }
</script>