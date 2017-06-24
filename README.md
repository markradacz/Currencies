# Currencies
Track Currencies on choosen markets.

![Currencies.png](https://steemitimages.com/DQmW4XRzkF7aebYsYn51dtSA2KHtTuDZJGCtpAdz8FtXtRd/Bez%C2%A0tytu%C5%82u.png)

Currencies allows you to be up-to-date with currencies and cryptocurriences values.

# Download

Application (.rar): [CLICK](https://1drv.ms/u/s!At9V322iaaJ1gWkm6U-6gAzFRXZ9)

Scan: [CLICK](https://www.virustotal.com/en/file/88cbe98bf9e1e40576a3edafcbc0f1857e909ee3718d169e37771fbaf8faab1d/analysis/1498317689/)

# Implemented Markets
Available Markets so far you are able to use:
* BitBay
   
   source: `https://bitbay.net/API/Public/{0}{1}/ticker.json`
* BitTrex


   source: `https://bittrex.com/api/v1.1/public/getmarketsummary?market={0}-{1}`
* CryptoCompare

   source: `https://cryptocompare.com/api/data/coinsnapshot/?fsym={0}&tsym={1}`
   
   First market from list will be used as CryptoCompare exchange.
   
   ## Information
   `{0} and {1} are replaced while application starting: {0} is Currency you want to exchange for {1}.`
   
   `IMPORTANT: Due to markets data limits you won't use some exchange currencies from each Market.`
   
   # Settings
   Each time you want to add new tracking you have to open settings.json and on the end of file **BEFORE** `]` add:
   
   `,
   {
      "Name":"SBD",
      "MarketName":"cryptocompare",
      "ExchangeCurrencies":[
         "BTC"
      ]
   }`
   
   **Name** - Currency you want to exchange.
   
   **MarketName** - Market name fromm exchange value will be downloaded. Available options: `bitbay` ,`bittrex`, `cryptocompare`.
   
   **ExchangeCurrencies** - currencies you want to be exchanged to.
   
   Code above will add trackings for SBD exchange to BTC (data from CryptoCompare Market).
   
   If you want to track currency exchange on the same market to multiple currencies you can use:
   
   `,
   {
      "Name":"BTC",
      "MarketName":"bittrex",
      "ExchangeCurrencies":[
         "LTC",
         "SBD",
         "STEEM"
      ]
   }
   `
   
   `IMPORTANT: It is possible not all exchanges are allowed by markets.`
   
   # FAQ
   ### Will new markets were added in the future?
   Of course. Let me know which markets you want were implemented.
      
  ### Setting.json file is hard to read.
     To make setting.json more readable use [JSON Formatter & Validator](https://jsonformatter.curiousconcept.com/).
     
  # Social
  [archerbest on Steemit](https://steemit.com/@archerbest)
