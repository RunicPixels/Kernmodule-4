<?php 
    // This is a simplified copy of the Login- and Score Systems to work with the Unity Post System, Unfortunately, Unity doesn't support cookies, so here's an edited copy specifically tailored to work with Unity.
    // (Not the most clean solution, but I didn't want to create a ton of complicated different files, just to account for session data)
    // (So this is a system that both logs in, and inserts a score, the other two files either log in (loginSystem.php) OR post the score.(scoreInsert.php)
    
    // Include database configuration settings.
    require_once "databaseConfig.php";
    
    // Define variables and initialize with empty values
    $username = $password = $score = $player_id =  "";

    $username = trim($_POST["username"]);
    $password = trim($_POST["password"]);
    $score    = trim($_POST["score"]);
    

    $sql = "SELECT id, username, password FROM users WHERE username = ?";

    $uidsql = "SELECT id FROM user WHERE username = $username LIMIT 1";
    $player_id = mysqli_query($link, $uidql);


    if($stmt = mysqli_prepare($link, $sql)){
        mysqli_stmt_bind_param($stmt, "s", $param_username);
        // Set parameters
        $param_username = $username;
        // Attempt to execute the prepared statement
        if(mysqli_stmt_execute($stmt)){
            // Store result
            mysqli_stmt_store_result($stmt);
            
            // Check if username exists, if yes then verify password
            if(mysqli_stmt_num_rows($stmt) == 1){                    
                // Bind result variables
                mysqli_stmt_bind_result($stmt, $player_id, $username, $hashed_password);
                // Save result variables to php variables.
                mysqli_stmt_fetch($stmt);
            }
            else {
                // Display an error message if username doesn't exist
                $username_err = "No account found with that username.";
                echo $username_err;
            }
        }
    }


    printf($player_id + " and " + $hashed_password);
    
    // Verify password regardless of outcome to prevent code from inserting scores when invalid password is inserted.    
    if(!password_verify($password, $hashed_password)){    
        $password_err = "The password you entered was not valid. - $password - $hashed_password";
        echo $password_err;
        exit();
    }   

    // Close statement
    mysqli_stmt_close($stmt);

    $sql = "INSERT INTO score (score, player_id, score_date) VALUES (?, ?, FROM_UNIXTIME(?))";

    if($stmt = mysqli_prepare($link, $sql)) {

        // Set parameters
        $param_score = $score;
        $param_uid = $player_id;
        $param_date = time();

        // Bind variables to the prepared statement as parameters
        mysqli_stmt_bind_param($stmt, "ssi", $param_score, $param_uid, $param_date);


        // Attempt to execute the prepared statement
        try {
            if(mysqli_stmt_execute($stmt) == true) { 
                //echo "Success!";
                return 1; // Succesful Return
            }
            else {
                printf("Error #%d: %s.\n", mysqli_stmt_errno($stmt), mysqli_stmt_error($stmt));
                return 0; // Failed Return
            }
        }
        catch (Exception $e){
            $error = $e->getMessage();
            echo $error;
        }

        // Close statement
        mysqli_stmt_close($stmt);
    }
// Close connection
mysqli_close($link);
 
?>