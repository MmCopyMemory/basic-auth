<?php
$link = mysqli_connect("db_adress", "db_username", "db_password", "db_name");
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = $_POST['username'];
    $password = $_POST['password'];
    $key = $_POST['key'];
    if (!empty($username) && !empty($password) && !empty($key)) {

        // KEY FILE!
        $keys = file("keys.txt", FILE_IGNORE_NEW_LINES);
        // KEY FILE!

        if (1 == 1) {
            $query = "SELECT * FROM users WHERE username = '$username'";
            $result = mysqli_query($link, $query);
            if (mysqli_num_rows($result) === 0) {
                $query = "INSERT INTO users (username, password) VALUES ('$username', '$password')";
                if (mysqli_query($link, $query)) {
                    $keys = array_diff($keys, array($key));

                    //KEY FILE
                    file_put_contents("keys.txt", implode("\n", $keys));
                    //KEY FILE!

                    // Return a success response
                    echo "good";
                } else {
                    // If the insert was unsuccessful, return an error response
                    echo "Error creating user";
                }
            } else {
                // If the username already exists, return an error response
                echo "username already exists";
            }
        } else {
            // If the key does not exist, return an error response
            echo "Invalid key";
        }
    } else {
        // If the username, password, or key is empty, return an error response
        echo "bad";
    }
} else {
    // If the request method is not POST, return an error response
    echo "bad";
}
?>
