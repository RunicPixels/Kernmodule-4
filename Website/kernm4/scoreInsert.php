<!doctype html>
<html lang="en">
<?php include 'checkLoggedIn.php'; include 'headContent.php'; include 'scoreSystem.php' ?>

<body class="bg-dark">
    <div class="container h-100">
        <div class="row h-100">
            <div class="col align-self-center text-center">
                <div class= "bg-light myForm">
                <form action = "<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">
                         <p>Add new scores for <?php echo $_SESSION["username"] ?>.</p>
                         <div class="form-group <?php echo (!empty($score_err)) ? 'has-error' : ''; ?>">
                              <label for="score">Score</label>
                              <input name = "score" class="form-control" id="score" placeholder="Insert new score...">
                              <small class="form-text text-muted"><?php echo $password_err; ?></small>
                         </div>
                         <div class="form-group">
                              <button type="submit" class="btn btn-primary">Insert Score</button>
                         </div>
                    </form>
                    <br>

                    <a href="https://ronaldvanegdom.nl/kernm4/scoreboard.php">Go to scoreboard</a><br>
                    <a href="https://ronaldvanegdom.nl/kernm4/logoutClient.php"><button type="submit" class="btn btn-primary">Log out</button></a>
                </div>
            </div>
        </div>
    </div>
</body>