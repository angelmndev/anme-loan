using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Presentacion.Helps
{
    public class DirectionImage
    {
        public enum fileImage
        {
            success,
            warning,
            danger,
            print,
            question,
            information
        }

        public string nameFileImage(fileImage fileImg)
        {
            string directionFileImage = "";
            switch (fileImg)
            {
                case fileImage.success:
                    directionFileImage = @"recursos/img/bien.png";
                    break;
                case fileImage.warning:
                    directionFileImage = @"recursos/img/bien.png";
                    break;
                case fileImage.danger:
                    directionFileImage = @"recursos/img/mal.png";
                    break;
                case fileImage.print:
                    directionFileImage = @"recursos/img/print.png";
                    break;
                case fileImage.question:
                    directionFileImage = @"recursos/img/question.png";
                    break;
                case fileImage.information:
                    directionFileImage = @"recursos/img/information.png";
                    break;
            }

            return directionFileImage;
        }
    }
}
