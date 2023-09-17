using Problems.Dtos;
using Problems.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Receipt
{
    public class ReadingReceipt
    {
        private int GetAverageCharacterHeight(List<ReceiptRequestDto> data)
        {
            decimal total = 0m;
            foreach (var item in data.Skip(1))
            {
                total += item.BoundingPoly.Vertices[3].Y - item.BoundingPoly.Vertices[0].Y;
            }
            return (int)total / data.Count - 1;
        }

        public List<ReceiptResponseDto> Read(List<ReceiptRequestDto> data)
        {
            int averageCharacterHeight = GetAverageCharacterHeight(data);

            List<List<ReceiptRequestDto>> dataList = new List<List<ReceiptRequestDto>>();
            dataList.Add(new List<ReceiptRequestDto>(data.Skip(1).Take(1)));
            foreach (var item in data.Skip(2).ToList())
            {
                var index = dataList.FindIndex(x => item.BoundingPoly.Vertices[0].Y - x[0].BoundingPoly.Vertices[0].Y < averageCharacterHeight);
                if (index == -1)
                    dataList.Add(new List<ReceiptRequestDto> { item });
                else
                {
                    dataList[index].Add(item);
                    dataList[index] = dataList[index].OrderBy(x => x.BoundingPoly.Vertices[1].X).ToList();
                }
            }

            return Response(dataList);
        }

        private List<ReceiptResponseDto> Response(List<List<ReceiptRequestDto>> data)
        {
            List<ReceiptResponseDto> responseDto = new List<ReceiptResponseDto>();
            foreach (var (item, index) in data.WithIndex())
            {
                string text = string.Empty;
                foreach (var subItem in item)
                {
                    text += subItem.Description + " ";
                }

                responseDto.Add(new ReceiptResponseDto { line = index + 1, Text = text });
            }
            return responseDto;
        }
    }
}
