
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <h3 align="center">Claytondus.PrintNode</h3>

  <p align="center">
    An unofficial .NET wrapper for the <a href="https://www.printnode.com">PrintNode</a> API.
    <br />
    <a href="https://github.com/claytondus/Claytondus.PrintNode/issues">Report Bug</a>
    ·
    <a href="https://github.com/claytondus/Claytondus.PrintNode/issues">Request Feature</a>
  </p>
</p>



<!-- ABOUT THE PROJECT -->
## About The Project

PrintNode is a remote printing API for web apps.  We use it at [Agonswim.com](https://www.agonswim.com) to print shipping labels and invoices.  It can also read shipping scales.

### Built With

* [JetBrains Rider](https://jetbrains.com/rider)
* [Flurl](https://flurl.dev)


## Usage

1. Get an account and API Key at [https://printnode.com](https://https://app.printnode.com/app/login/register)
2. Clone the repo
   ```sh
   dotnet add package Claytondus.PrintNode
   ```
3. Instantiate the client
   ```C#
   var apiKey = "....";
   var client = new PrintNodeClient(apiKey);
   ```
   You may also pass in an ILogger to log requests and responses:
   ```C#
   var client = new PrintNodeClient(apiKey, logger);
   ```
4. Call the API
   ```C#
   var response = await client.GetPrintJobsAsync();
   ```

### API Support
* GET /whoami
* GET /computers
* GET /printers
* GET /printjobs
* POST /printjobs
* GET /computer/COMPUTER_ID/scales

Additional APIs are supported upon request.



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

I AM NOT AFFILIATED WITH PRINTNODE, LTD.  For questions about their service please contact support@printnode.com or @PrintNode on twitter.

Clayton Davis - cd@ae4ax.net

Project Link: [https://github.com/claytondus/Claytondus.PrintNode](https://github.com/claytondus/Claytondus.PrintNode)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [PrintNode](https://printnode.com)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/claytondus/Claytondus.PrintNode.svg?style=for-the-badge
[contributors-url]: https://github.com/claytondus/Claytondus.PrintNode/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/claytondus/Claytondus.PrintNode.svg?style=for-the-badge
[forks-url]: https://github.com/claytondus/Claytondus.PrintNode/network/members
[stars-shield]: https://img.shields.io/github/stars/claytondus/Claytondus.PrintNode.svg?style=for-the-badge
[stars-url]: https://github.com/claytondus/Claytondus.PrintNode/stargazers
[issues-shield]: https://img.shields.io/github/issues/claytondus/Claytondus.PrintNode.svg?style=for-the-badge
[issues-url]: https://github.com/claytondus/Claytondus.PrintNode/issues
[license-shield]: https://img.shields.io/github/license/claytondus/Claytondus.PrintNode.svg?style=for-the-badge
[license-url]: https://github.com/claytondus/Claytondus.PrintNode/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/claytond
