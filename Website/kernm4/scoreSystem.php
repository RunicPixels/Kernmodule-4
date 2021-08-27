<?php 
     session_start();

     // Include database configuration settings.
     require_once "databaseConfig.php";
     
     // Define variables and initialize with empty values
     $score = "";
     $score_err = "";
     $player_id = "";


    // Check if score is empty
    if(empty(trim($_POST["score"]))) {
        $score_err = "Insert your new score...";
    } else {
        $score = trim($_POST["score"]);
    }
    // Validate credentials
    if(empty($score_err)){
        
        if($username == '') $username = $_POST["username"]; // First check for a specified post username.    

        else {
            $username = $_SESSION['username']; // Otherwise fall back to session username.
            echo "Using session username";     
        }
        
        
        // Prepare a select statement
        $sql = "SELECT id, player_id, score FROM score";

        $uidsql = "SELECT id FROM user WHERE username = $username LIMIT 1";
        $uid = mysqli_query($link, $uidql);
        echo $uid;


        if($stmt = mysqli_prepare($link, $sql)){
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "s", $param_score);
            
            // Set parameters
            $param_score = trim($_POST["score"]);
            
            // Attempt to execute the prepared statement
            if(mysqli_stmt_execute($stmt)){
                /* store result */
                mysqli_stmt_store_result($stmt);
                
                $score_err = trim($_POST["score"]);
            } else{
                echo "Oops! Something went wrong. Please try again later. (1)";
                return 0; // Failed Return
            }

            // Check input errors before inserting in database
            if(empty($score_err)){
                $score_err = "Please enter a score.";
                echo $score_err;
            }
            
            $score = $score_err;

            // Getting Player ID;
            $player_id = $_SESSION['id'];


            // Prepare an insert statement
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
                        echo "Success!";
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
        }
    }
?>
