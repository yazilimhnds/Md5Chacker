<?php
if($_GET["hash"]) {
$hash = $_GET["hash"];
$hash_type = "md5";
$email = "info@bizimbilisim.com";
$code = "34f0b6ca7a5133ff";
$response = file_get_contents("http://md5decrypt.net/Api/api.php?hash=".$hash."&hash_type=".$hash_type."&email=".$email."&code=".$code);
echo $response;
}
?>