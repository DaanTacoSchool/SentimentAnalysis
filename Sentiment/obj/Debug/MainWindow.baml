   M S B A M L   `   `   `  ����D  @Sentiment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Sentiment	Sentiment  5   	       Sentiment.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Sentiment     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ btnSelectPHP��5
      $��Select PHP.exe��6'   $
��Left=�6@   $��	19,10,0,0q�6[   $	��Top=�6n   $	��112��6�   $��23��6�   6�   �� 5   
   -   5        $ btnSentiment��5      $��Sentiment Analysis��6'   $
��Left=�6D   $��	19,94,0,0q�6_   $	��Top=�6r   $	��112��6�   $��23��6�   {�.  6�   �� 5   
   -   5         ��Name$ 	sentiment��5      $
��Left=�6%   $��23��6@   $��
150,94,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $��SentimentScore.txt��6t   $	��Top=�6�   $	��120��6�   $��Center=�6�   �� 5   
   -   5        $ tweets��5      $
��Left=�6"   $��23��6=   $��
275,94,0,0q�6I   $
 Wrap=�6]   $��
tweets.txt��6q   $	��Top=�6�   $	��120��6�   $��Center=�6�    J� RenderTransformOrigin$ 
0.477,0.52&�6�   �� 5   
   -   5        $ phpPath��5      $
��Left=�6#   $��23��6>   $��
150,10,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��245��6�   $��Center=�6�   �� 5   
   -   5        $ 	txtStatus��5      $
��Left=�6%   $��23��6@   $��
275,38,0,0q�6L   $
 Wrap=�6`   $	��Off��6t   $	��Top=�6   $	��120��6�   $��Center=�6�   �� 5   
   -   5        $ btnStartServer��5      $��Start Server��6)   $
��Left=�6@   $��	19,38,0,0q�6[   $	��Top=�6n   $	��112��6�   $��23��6�   {�.  6�   �� 5   
   -   5        $ btnRetrieveTweets��5      $��Retrieve new tweets��6,   $
��Left=�6J   $��	19,66,0,0q�6e   $	��Top=�6x   $	��112��6�   $��23��6�   {�.  6�   �� 5   
   -	   5        $ txtTweetSucces��5      $
��Left=�6*   $��23��6E   $��
275,66,0,0q�6Q   $
 Wrap=�6e   $��--��6y   $	��Top=�6�   $	��120��6�   $��Center=�6�   �� 5   
   -
   5        $ txtPort��5      $
��Left=�6#   $��23��6>   $��
150,38,0,0q�6J   $
 Wrap=�6^   $
��Port��6r   $	��Top=�6~   $	��120��6�   $ 0.236,0.878&�6�   $��Center=�6�   �� 5   
   -   5        $ txtNumTweets��5      $
��Left=�6(   $��23��6C   $��
150,66,0,0q�6O   $
 Wrap=�6c   $��20��6w   $	��Top=�6�   $	��120��6�   $��Center=�6�   �� 5   
   -   5        $ btnTermFrequency��5      $��Term Frequency��6+   $
��Left=�6D   $��
19,121,0,0q�6_   $	��Top=�6s   $	��112��6�   $��24��6�   {�.  6�   �� 5   
   -   5        $ txtFrequency��5      $
��Left=�6(   $��23��6C   $��150,122,0,0q�6O   $
 Wrap=�6d   $��
tweets.txt��6x   $	��Top=�6�   $	��120��6�   $��Center=�6�   �� 5   
   -   5        $ txtStateMoods��5      $
��Left=�6)   $��23��6D   $��275,150,0,0q�6P   $
 Wrap=�6e   $��
tweets.txt��6y   $	��Top=�6�   $	��120��6�   $��Center=�6�   �� 5   
   -   5        $ btnStateMood��5      $��Happiest State��6'   $
��Left=�6@   $��
19,150,0,0q�6[   $	��Top=�6o   $	��112��6�   $��23��6�   {�.  6�   �� 5   
   -   5        $ txtStatemoodsSent��5      $
��Left=�6-   $��23��6H   $��150,150,0,0q�6T   $
 Wrap=�6i   $��SentimentScore.txt��6}   $	��Top=�6�   $	��120��6�   $��Center=�6�   $ 0.499,0.602&�6	  �� 5   
   -   5        $ txtHash��5      $
��Left=�6#   $��23��6>   $��150,178,0,0q�6J   $
 Wrap=�6_   $��
tweets.txt��6s   $	��Top=�6�   $	��120��6�   $��Center=�6�   �� 5   
   -   5        $ btnHashtags��5      $��Common Hashtags��6&   $
��Left=�6@   $��
19,178,0,0q�6[   $	��Top=�6o   $	��112��6�   $��23��6�   {�.  6�   �� 5   
   $
��Left=�6   $��
19,206,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $	��105��6o   $	��394��6|   �� 6�   $���PHP 5.4.1+ required to run the scripts. Server only required when retrieving new tweets* (min 1 max 100). Tweets without text will not be included in Sentiment Analysis.��6�   �� 6@  �� 6L  $s�mPlace SentimentScore.txt and file with tweets in same folder as executable for the program to work correctly.��6P  �� 6�  �� 6�  $J�D*Place cacert.pem in "C:/" to retrieve new tweets. (SSL certificate)��6�  60  5      5      