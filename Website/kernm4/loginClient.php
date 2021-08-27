<!doctype html>
<html lang="en">
<?php include 'loginSystem.php'; include 'headContent.php'; ?>
<title>loginClient.php</title>

<body class="bg-dark">
     <div class="container h-100">
          <div class="row h-100">
               <div class="col align-self-center text-center">
                    <h2 class="text-light">Login</h2>
                    <form action = "<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post" class= "bg-light myForm">
                         <p>Welcome To the Waddoo portal to log into the kernmodule 4 database!</p>
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
                         <div class="form-group">
                              <button type="submit" class="btn btn-primary" value="Login">Login</button>
                         </div>
                         <p>Want to create an account? <a href="registrationClient.php">Register here</a>.</p>
                    </form>
               </div>
          </div>
     </div>
</body>

</html>