<!doctype html>
<html lang="en">
<?php include 'checkLoggedIn.php'; include 'headContent.php'; ?>

<body class="bg-dark">
    <div class="container h-100">
        <div class="row h-100">
            <div class="col align-self-center text-center">
                <div class= "bg-light myForm">
                <p>ID:<?php echo $_SESSION['id']; ?> </p> 
                <p>Welcome <?php echo $_SESSION["username"]; ?>.</p> 
                <form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
                    <select name="Time">
                        <option value="">All time</option>
                        <option value="1 YEAR">Past Year</option>
                        <option value="1 MONTH">Past Month</option>
                        <option value="1 DAY">Past Day</option>
                    </select>
                    <select name="Amount">
                        <option value="5">Top 5</option>
                        <option value="10">Top 10</option>
                        <option value="100"> Top 100</option>
                    </select>
                    <input type='submit'>
                </form>
                <table class = "table">
                    <tr>
                        <th scope = "col">Position</th>
                        <th scope = "col">Username</th>
                        <th scope = "col">Score</th>
                        <th scope = "col">Date</th>
                    </tr>
                    <?php
                        // Initiating Base Query Component Variables
                        $querystart = '';
                        $querytime = '';
                        $queryamount = '';
                        $querysort = '';

                        // Defining base query
                        $querystart = "SELECT s.id, s.player_id, s.score, s.score_date, u.id, u.username 
                        FROM score AS s INNER JOIN users AS u ON (s.player_id=u.id)";
                        
                        // Defining time constraints
                        $time = $_POST['Time'];
                        $today = "CURDATE()";

                        if($time != "") $querytime = " WHERE score_date BETWEEN DATE_SUB(CURDATE(), INTERVAL $time) AND CURDATE()";

                        // Limit
                        $amount = $_POST['Amount'];
                        $queryamount = " LIMIT $amount ";


                        // Sorting Query
                        $querysort = "ORDER BY s.score DESC";

                        // Combining query
                        $scorequery = $querystart . $querytime . $querysort . $queryamount;

                        // Query Result & Fetching
                        $scoreResult = mysqli_query($link, $scorequery);
                        $num = 0;


                        // Displaying Results

                        $timequote = '';

                        switch($time) {
                            case '':
                                $timequote = "of all time.";
                            break;
                            case '1 DAY':
                                $timequote = "from the last day.";
                            break;
                            case '1 MONTH':
                                $timequote = "from the last month.";
                            break;
                            case '1 YEAR':
                                $timequote = "from the last year.";
                            break;
                        }

                        echo "<p> Displaying the top " . $amount . " scores " . $timequote . "</p>";
                        while( $row = $scoreResult->fetch_array() )
                        {
                            // Top 3 Gold / Silver / Bronze Combo.
                            switch($num) {
                                case 0:
                                    echo"<tr style='background-color:#FFEF99'>";
                                break;
                                case 1 :
                                    echo"<tr style='background-color:#E3E3E3'>";
                                break;
                                case 2 :
                                    echo"<tr style='background-color:#EAC9AF'>";
                                break;
                                default :
                                    echo "<tr>";
                                break;
                            }
                            $num += 1;
                            $trophy = $num <= 3 ? '🏆 ' : '';
                            
                            // Displaying Results
                            echo "<th scope = 'row'>" . $num . "</th>"; 
                            echo "<th>" . $row['username'] . "</th>";
                            echo "<th>" . $trophy . $row['score'] . " points</th>";
                            echo "<th>" . $row['score_date'] . "</tr></tr>";
                        }
                    ?>     



                </table>       

                <a href="https://ronaldvanegdom.nl/kernm4/scoreInsert.php">Go to score insert</a><br>
                    <a href="https://ronaldvanegdom.nl/kernm4/logoutClient.php"><button type="submit" class="btn btn-primary">Log out</button></a>
                </div>
            </div>
        </div>
    </div>
</body>

