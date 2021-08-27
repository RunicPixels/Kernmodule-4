<!doctype html>
<html lang="en">
<?php include 'registrationSystem.php'; include 'headContent.php'; ?>
<title>registrationClient.php</title>

<body class="bg-dark">
     <div class="container h-100">
          <div class="row h-100">
               <div class="col align-self-center text-center">
                    <h2 class="text-light">Sign-Up for Waddoo (Kernmodule 4)</h2>
                    <form action = "<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post" class= "bg-light myForm">
                        <p>Register your waddoo account!</p>
                        <div class="form-group <?php echo (!empty($username_err)) ? 'has-error' : ''; ?>">
                            <label for="usename">Username / Email</label>
                            <input type="text" name = "username" class="form-control" id="username" placeholder="Enter your username / email adress">
                            <small class="form-text text-muted"><?php echo $username_err; ?></small>
                        </div>
                        <div class="form-group <?php echo (!empty($password_err)) ? 'has-error' : ''; ?>">
                            <label for="password">Password</label>
                            <input type="password" name = "password" class="form-control" id="password" placeholder="Enter your password">
                            <small class="form-text text-muted"><?php echo $password_err; ?></small>
                        </div>
                        <div class="form-group <?php echo (!empty($confirm_password_err)) ? 'has-error' : ''; ?>">
                            <label>Confirm Password</label>
                            <input type="password" name="confirm_password" class="form-control" placeholder="Confirm your password" value="<?php echo $confirm_password; ?>">
                            <span class="help-block"><?php echo $confirm_password_err; ?></span>
                        </div>
                        <div class="form-group">
                            <button type="submit" class="btn btn-primary" value="Login">Register</button>
                        </div>
                        <p>Already have an account? <a href="loginClient.php">Login here</a>.</p>
                    </form>
               </div>
          </div>
     </div>
</body>

</html>





