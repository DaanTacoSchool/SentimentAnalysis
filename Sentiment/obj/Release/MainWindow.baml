   M S B A M L   `   `   `  ���� D  @Sentiment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Sentiment	Sentiment      Sentiment.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:Sentiment       � Title$  
MainWindow��$	��350��$	��525��.��� .+��� -    ��Name$ btnSelectPHP��$��Select PHP.exe��$
��Left=�$��	19,10,0,0q�$	��Top=�$	��112��$��23���� -   $ btnSentiment��$��Sentiment Analysis��$
��Left=�$��	19,94,0,0q�$	��Top=�$	��112��$��23��{�.  �� -    ��Name$ 	sentiment��$
��Left=�$��23��$��
150,94,0,0q� �� TextWrapping$
 Wrap=�$��SentimentScore.txt��$	��Top=�$	��120��$��Center=��� -   $ tweets��$
��Left=�$��23��$��
275,94,0,0q�$
 Wrap=�$��
tweets.txt��$	��Top=�$	��120��$��Center=� J� RenderTransformOrigin$ 
0.477,0.52&��� -   $ phpPath��$
��Left=�$��23��$��
150,10,0,0q�$
 Wrap=�$	��Top=�$	��245��$��Center=��� -   $ 	txtStatus��$
��Left=�$��23��$��
275,38,0,0q�$
 Wrap=�$	��Off��$	��Top=�$	��120��$��Center=��� -   $ btnStartServer��$��Start Server��$
��Left=�$��	19,38,0,0q�$	��Top=�$	��112��$��23��{�.  �� -   $ btnRetrieveTweets��$��Retrieve new tweets��$
��Left=�$��	19,66,0,0q�$	��Top=�$	��112��$��23��{�.  �� -	   $ txtTweetSucces��$
��Left=�$��23��$��
275,66,0,0q�$
 Wrap=�$��--��$	��Top=�$	��120��$��Center=��� -
   $ txtPort��$
��Left=�$��23��$��
150,38,0,0q�$
 Wrap=�$
��Port��$	��Top=�$	��120��$ 0.236,0.878&�$��Center=��� -   $ txtNumTweets��$
��Left=�$��23��$��
150,66,0,0q�$
 Wrap=�$��20��$	��Top=�$	��120��$��Center=��� -   $ btnTermFrequency��$��Term Frequency��$
��Left=�$��
19,121,0,0q�$	��Top=�$	��112��$��24��{�.  �� -   $ txtFrequency��$
��Left=�$��23��$��150,122,0,0q�$
 Wrap=�$��
tweets.txt��$	��Top=�$	��120��$��Center=��� -   $ txtStateMoods��$
��Left=�$��23��$��275,150,0,0q�$
 Wrap=�$��
tweets.txt��$	��Top=�$	��120��$��Center=��� -   $ btnStateMood��$��Happiest State��$
��Left=�$��
19,150,0,0q�$	��Top=�$	��112��$��23��{�.  �� -   $ txtStatemoodsSent��$
��Left=�$��23��$��150,150,0,0q�$
 Wrap=�$��SentimentScore.txt��$	��Top=�$	��120��$��Center=�$ 0.499,0.602&��� -   $ txtHash��$
��Left=�$��23��$��150,178,0,0q�$
 Wrap=�$��
tweets.txt��$	��Top=�$	��120��$��Center=��� -   $ btnHashtags��$��Common Hashtags��$
��Left=�$��
19,178,0,0q�$	��Top=�$	��112��$��23��{�.  �� $
��Left=�$��
19,206,0,0q�$
��Wrap=�$	��Top=�$	��105��$	��394���� $���PHP 5.4.1+ required to run the scripts. Server only required when retrieving new tweets* (min 1 max 100). Tweets without text will not be included in Sentiment Analysis.���� �� $s�mPlace SentimentScore.txt and file with tweets in same folder as executable for the program to work correctly.���� �� $J�D*Place cacert.pem in "C:/" to retrieve new tweets. (SSL certificate)��