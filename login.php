<?php
$link = mysqli_connect("db_adress", "db_username", "db_password", "db_name");
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = $_POST['username'];
    $password = $_POST['password'];
    if (!empty($username) && !empty($password)) {
        $query = "SELECT * FROM users WHERE username = '$username' AND password = '$password'";
        $result = mysqli_query($link, $query);
        if (mysqli_num_rows($result) === 1) {
            // If the username and password match a user, return a success response
            echo "good";
        } else {
            // If the username and password do not match a user, return an error response
            echo "bad";
        }
    } else {
        // If the username or password is empty, return an error response
        echo "bad";
    }
} else {
    // If the request method is not POST, return an error response
    echo "bad";
}
?>