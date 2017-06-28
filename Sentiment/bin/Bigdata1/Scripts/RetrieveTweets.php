<?php


//Define('curl.cainfo', 'c:\cacert.pem');
ini_set('curl.cainfo', 'c:\cacert.pem');
require_once "TwitterAPIExchange.php";
$count=20;
if(isset($_GET['NT'])){
	$count=$_GET['NT'];
	$tweetnum= '?q=microsoft&count='.$count;
	echo $tweetnum;
}
$settings = array(
    'oauth_access_token' => "850317119254401024-5rEdHUtNiWHlB76xx8B9jZxOZRHEll6",
    'oauth_access_token_secret' => "Gittob74n7JKbqBzuVL7sR42ELRsl5tmJyPaFrbwpWcjB",
    'consumer_key' => "5gylIlPTczLvjYD1uz1cEtRAA",
    'consumer_secret' => "HOjfSJR4HgaeFQZlDazhGwpCTsOOu0DNojcsC9ieATLfxmG1nY"
);

$url = 'https://api.twitter.com/1.1/search/tweets.json';
$getField = $tweetnum;

$twitter = new TwitterAPIExchange($settings);

echo 'Getting Twitter data...';

$result = $twitter->setGetfield($getField)
    ->buildOauth($url, 'GET')
    ->performRequest();

file_put_contents('../Userfiles/tweets.txt', $result);

echo "\r\nTwitter data successfully written to tweets.txt.";
/*

Define('curl.cainfo', 'c:\cacert.pem');
ini_set('curl.cainfo', 'c:\cacert.pem');
require_once "TwitterAPIExchange.php";

$settings = array(
    'oauth_access_token' => "850317119254401024-5rEdHUtNiWHlB76xx8B9jZxOZRHEll6",
    'oauth_access_token_secret' => "Gittob74n7JKbqBzuVL7sR42ELRsl5tmJyPaFrbwpWcjB",
    'consumer_key' => "5gylIlPTczLvjYD1uz1cEtRAA",
    'consumer_secret' => "HOjfSJR4HgaeFQZlDazhGwpCTsOOu0DNojcsC9ieATLfxmG1nY"
);

$url = 'https://api.twitter.com/1.1/search/tweets.json';
$getField = '?q=microsoft&count=500';

$twitter = new TwitterAPIExchange($settings);

echo 'Getting Twitter data...';

$result = $twitter->setGetfield($getField)
    ->buildOauth($url, 'GET')
    ->performRequest();

file_put_contents('tweets.txt', $result);

echo "\r\nTwitter data successfully written to tweets.txt.";*/